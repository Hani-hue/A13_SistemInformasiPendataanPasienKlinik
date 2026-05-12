using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    public partial class FormDashboardAdmin : Form
    {
        // Alamat database 
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=klinik_db;Integrated Security=True";

        public FormDashboardAdmin()
        {
            InitializeComponent();
            TampilkanData(); // Memanggil data otomatis saat form terbuka
        }



        private BindingSource bindingSource = new BindingSource();
        private DataTable dtPasien = new DataTable();

        private void FormPasien_Load(object sender, EventArgs e)
        {
            // Mengatur ComboBox Jenis Kelamin secara manual [cite: 397]
            cbJnsKelamin.DataSource = new string[] { "Laki-laki", "Perempuan" };

           // Konfigurasi DataGridView agar rapi [cite: 398, 403]
            dgvPasien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasien.ReadOnly = true;
            dgvPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TampilkanData(); // Memanggil fungsi load data
        }

        // TAMPILKAN DATA & BAGIAN EXECUTE SCALAR ---
        private void TampilkanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM vwPasienPublic"; // Menggunakan VIEW 
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtPasien = new DataTable();
                        da.Fill(dtPasien);
                        bindingSource.DataSource = dtPasien;
                        dgvPasien.DataSource = bindingSource;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load data: " + ex.Message); }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // BAGIAN F: Validasi Input agar tidak kosong
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("Nama dan Alamat tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Perintah INSERT untuk memasukkan data baru
                    string query = "INSERT INTO Pasien (nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin) " + " VALUES (@nama, @alamat, @telp, @tgl, @jk)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Menggunakan Parameter (@) agar aman dari SQL Injection (Hacker)
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@telp", txtTelp.Text);
                    cmd.Parameters.AddWithValue("@tgl", dtpLahir.Value);
                    cmd.Parameters.AddWithValue("@jk", cbJnsKelamin.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Eksekusi perintah simpan
                    MessageBox.Show("Data Pasien Berhasil Disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm(); // Bersihkan textbox setelah simpan
                    TampilkanData(); // Refresh tabel agar data pasien baru muncul
                }
                catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            // Pastikan admin sudah pilih data di tabel (ID Pasien nggak boleh kosong)
            if (string.IsNullOrEmpty(txtIDPasien.Text))
            {
                MessageBox.Show("Pilih data yang ingin diubah dari tabel terlebih dahulu!");
                return;
            }

            // BAGIAN F: Konfirmasi sebelum ubah dan agar ga salah klik
            if (MessageBox.Show("Yakin ingin mengubah data ini?", "Konfirmasi Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Perintah UPDATE berdasarkan id_pasien yang dipilih
                        string query = "UPDATE Pasien SET nama_pasien=@nama, alamat=@alamat, no_telepon=@telp, tanggal_lahir=@tgl, jenis_kelamin=@jk WHERE id_pasien=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", txtIDPasien.Text);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                        cmd.Parameters.AddWithValue("@telp", txtTelp.Text);
                        cmd.Parameters.AddWithValue("@tgl", dtpLahir.Value);
                        cmd.Parameters.AddWithValue("@jk", cbJnsKelamin.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Diperbarui!");
                        TampilkanData();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDPasien.Text))
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
                return;
            }

            // Konfirmasi sebelum hapus
            if (MessageBox.Show("Data akan dihapus permanen. Lanjutkan?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Perintah DELETE: Hati-hati, harus pakai WHERE id_pasien supaya ga ke hapus semua data yg lain
                        string query = "DELETE FROM Pasien WHERE id_pasien=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", txtIDPasien.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Pasien Telah Dihapus!");
                        ClearForm();
                        TampilkanData();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
                }
            }
        }

        private void dgvPasien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Pastikan yang diklik adalah baris data, bukan judul kolom
            {
                DataGridViewRow row = dgvPasien.Rows[e.RowIndex];

                // Pastikan yang diklik adalah baris data, bukan judul kolom
                txtIDPasien.Text = row.Cells["id_pasien"].Value.ToString();
                txtNama.Text = row.Cells["nama_pasien"].Value.ToString(); // Pakai nama_pasien
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                txtTelp.Text = row.Cells["no_telepon"].Value.ToString(); // Pakai no_telepon
                dtpLahir.Value = Convert.ToDateTime(row.Cells["tanggal_lahir"].Value); // Pakai tanggal_lahir
                cbJnsKelamin.Text = row.Cells["jenis_kelamin"].Value.ToString(); // Pakai jenis_kelamin
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Memanggil untuk balik Form Menu Utama
            DashboardAdminNew menuUtama = new DashboardAdminNew();
            menuUtama.Show();

            // Menutup Form Kelola ini agar tidak menumpuk di memori
            this.Close();
        }

        private void ClearForm()
        {
            txtIDPasien.Clear();
            txtNama.Clear();
            txtAlamat.Clear();
            txtTelp.Clear();
            cbJnsKelamin.SelectedIndex = -1;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtIDPasien.Clear(); // Berdasarkan properti
            txtNama.Clear();     // Berdasarkan properti
            txtAlamat.Clear();   // Berdasarkan properti
            txtTelp.Clear();     // Berdasarkan properti

            // Mengatur ulang ComboBox
            // Jika menggunakan dropdown list, set index ke -1 atau 0
            cbJnsKelamin.SelectedIndex = -1; // Berdasarkan properti

            // Mengatur ulang DateTimePicker ke tanggal hari ini
            dtpLahir.Value = DateTime.Now;   // Berdasarkan properti

            // Mengembalikan fokus ke inputan pertama
            txtIDPasien.Focus();
        }

        private void btnTestInject_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL INJECTION TEST: Menggabungkan string secara langsung sangat berbahaya
                    // Kita ubah target ke tabel pasien dan kolom id_pasien
                    string query = "UPDATE pasien SET nama_pasien='HACKED' WHERE id_pasien='" + txtIDPasien.Text + "'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris terupdate", "Hasil Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                TampilkanData(); // Refresh tabel setelah pengetesan
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query disesuaikan untuk tabel pasien dan pasien_backup
                    string query = @"
                IF OBJECT_ID('dbo.pasien_backup') IS NOT NULL
                BEGIN
                    DELETE FROM dbo.pasien;
                    INSERT INTO dbo.pasien (nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin)
                    SELECT nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin 
                    FROM dbo.pasien_backup;
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data pasien berhasil direset", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanData(); // Memanggil fungsi refresh tabel kamu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}