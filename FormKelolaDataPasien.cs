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

        // TAMPILKAN DATA & BAGIAN EXECUTE SCALAR ---
        private void TampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // PENGAMAN: Buka koneksi di awal blok try
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Perintah buat ambil semua data penting pasien
                    string query = "SELECT id_pasien, nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin FROM pasien";

                    //untuk bawa tabel dari sql ke c#
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable(); //wadah tabel
                    adapter.Fill(dt);
                    dgvPasien.DataSource = dt; //tampilkan isi wadah ke tabel yang ada di datagridview

                    // BAGIAN EXECUTE SCALAR: Menghitung total pasien
                    SqlCommand cmdSum = new SqlCommand("SELECT COUNT(*) FROM pasien", conn);

                    // ExecuteScalar mengambil angka hasil hitungan (1 nilai saja) dan tampilkan ke label
                    label1.Text = "Total Pasien: " + cmdSum.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Memuat Data: " + ex.Message);
                }
            }
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
    }
}