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
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtTelp.Text))
            {
                MessageBox.Show("Nama dan Nomor Telepon harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // 2. Memanggil nama Stored Procedure yang sudah dibuat di SQL Server
                    SqlCommand cmd = new SqlCommand("sp_InsertPasien", conn);

                    // 3. WAJIB: Atur CommandType menjadi StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 4. Masukkan parameter (Nama parameter @ harus persis dengan di SQL Server)
                    cmd.Parameters.AddWithValue("@NamaPasien", txtNama.Text);
                    cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@NoTelepon", txtTelp.Text);
                    cmd.Parameters.AddWithValue("@TanggalLahir", dtpLahir.Value.Date);
                    cmd.Parameters.AddWithValue("@JenisKelamin", cbJnsKelamin.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Eksekusi prosedur

                    MessageBox.Show("Data Pasien Berhasil Ditambahkan (via Stored Procedure)!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Bersihkan form dan refresh tabel
                    ClearForm();
                    TampilkanData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Simpan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIDPasien.Text))
            {
                MessageBox.Show("Pilih data pasien yang akan diupdate!");
                return;
            }

            if (MessageBox.Show("Yakin ingin mengubah data?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Memanggil nama Stored Procedure
                        SqlCommand cmd = new SqlCommand("sp_UpdatePasien", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parameter harus sesuai dengan yang ada di SQL Server
                        cmd.Parameters.AddWithValue("@IdPasien", txtIDPasien.Text);
                        cmd.Parameters.AddWithValue("@NamaPasien", txtNama.Text);
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                        cmd.Parameters.AddWithValue("@NoTelepon", txtTelp.Text);
                        cmd.Parameters.AddWithValue("@TanggalLahir", dtpLahir.Value.Date);
                        cmd.Parameters.AddWithValue("@JenisKelamin", cbJnsKelamin.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Pasien Berhasil Diperbarui via Stored Procedure!");

                        TampilkanData();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDPasien.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Memanggil nama Stored Procedure
                        SqlCommand cmd = new SqlCommand("sp_DeletePasien", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Hanya butuh parameter ID
                        cmd.Parameters.AddWithValue("@IdPasien", txtIDPasien.Text);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Berhasil Dihapus!");
                            TampilkanData();
                        }
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

        private void BindControls()
        {
            // Menghapus binding lama agar tidak terjadi duplikasi/error
            txtIDPasien.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtTelp.DataBindings.Clear();
            dtpLahir.DataBindings.Clear();
            cbJnsKelamin.DataBindings.Clear();

            // Menghubungkan setiap kolom di DataTable/View ke TextBox masing-masing
            // Format: ("Properti_Komponen", DataSource, "Nama_Kolom_Database")
            txtIDPasien.DataBindings.Add("Text", bindingSource, "id_pasien");
            txtNama.DataBindings.Add("Text", bindingSource, "nama_pasien");
            txtAlamat.DataBindings.Add("Text", bindingSource, "alamat");
            txtTelp.DataBindings.Add("Text", bindingSource, "no_telepon");

            // Binding untuk DateTimePicker (menggunakan properti Value)
            dtpLahir.DataBindings.Add("Value", bindingSource, "tanggal_lahir");

            // Binding untuk ComboBox Jenis Kelamin
            cbJnsKelamin.DataBindings.Add("Text", bindingSource, "jenis_kelamin");
        }

    }

}