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
            // Method ini dibiarkan sesuai aslinya, namun disarankan panggil TampilkanData() saja agar konsisten
            TampilkanData();
        }

        // TAMPILKAN DATA & BAGIAN EXECUTE SCALAR ---
        private void TampilkanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM vwPasienPublic";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtPasien = new DataTable();
                        da.Fill(dtPasien);

                        bindingSource.DataSource = null;
                        bindingSource.DataSource = dtPasien;
                        dgvPasien.DataSource = bindingSource;

                        // TAMBAHKAN BARIS INI:
                        // Ini untuk menyambungkan angka "0 of 0" di Navigator ke data Anda
                        bindingNavigator1.BindingSource = bindingSource;

                        BindControls();
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
                    SqlCommand cmd = new SqlCommand("sp_InsertPasien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nama_pasien", txtNama.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@no_telepon", txtTelp.Text);
                    cmd.Parameters.AddWithValue("@tanggal_lahir", dtpLahir.Value.Date);
                    cmd.Parameters.AddWithValue("@jenis_kelamin", cbJnsKelamin.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Pasien Berhasil Ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        SqlCommand cmd = new SqlCommand("sp_UpdatePasien", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // PERBAIKAN: Menambahkan parameter @IdPasien yang sebelumnya hilang
                        cmd.Parameters.AddWithValue("@IdPasien", txtIDPasien.Text);
                        cmd.Parameters.AddWithValue("@nama_pasien", txtNama.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                        cmd.Parameters.AddWithValue("@no_telepon", txtTelp.Text);
                        cmd.Parameters.AddWithValue("@tanggal_lahir", dtpLahir.Value.Date);
                        cmd.Parameters.AddWithValue("@jenis_kelamin", cbJnsKelamin.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Pasien Berhasil Diperbarui!");

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
                        SqlCommand cmd = new SqlCommand("sp_DeletePasien", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPasien.Rows[e.RowIndex];

                txtIDPasien.Text = row.Cells["id_pasien"].Value.ToString();
                txtNama.Text = row.Cells["nama_pasien"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                txtTelp.Text = row.Cells["no_telepon"].Value.ToString();

                // PERBAIKAN: Cek DBNull untuk menghindari crash
                if (row.Cells["tanggal_lahir"].Value != DBNull.Value)
                    dtpLahir.Value = Convert.ToDateTime(row.Cells["tanggal_lahir"].Value);

                cbJnsKelamin.Text = row.Cells["jenis_kelamin"].Value.ToString();
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            DashboardAdminNew menuUtama = new DashboardAdminNew();
            menuUtama.Show();
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
            ClearForm();
            dtpLahir.Value = DateTime.Now;
            txtIDPasien.Focus();
        }

        private void btnTestInject_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // PERBAIKAN: Menggunakan Parameterized Query untuk keamanan
                    string query = "UPDATE pasien SET nama_pasien='HACKED' WHERE id_pasien = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIDPasien.Text);
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris terupdate", "Hasil Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                IF OBJECT_ID('dbo.pasien_backup') IS NOT NULL
                BEGIN
                    -- 1. Hapus rekam medis dulu karena mereka merujuk ke pasien
                    DELETE FROM dbo.rekam_medis;

                    -- 2. Baru aman menghapus data pasien
                    DELETE FROM dbo.pasien;

                    -- 3. Reset hitungan ID ke 0 agar data baru mulai dari 1
                    DBCC CHECKIDENT ('dbo.pasien', RESEED, 0); 

                    -- 4. Masukkan kembali data dari backup
                    INSERT INTO dbo.pasien (nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin)
                    SELECT nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin 
                    FROM dbo.pasien_backup;
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil direset!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Reset gagal: " + ex.Message); }
        }

        private void BindControls()
        {
            // PERBAIKAN: Bersihkan semua binding lama agar tidak bentrok
            txtIDPasien.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtTelp.DataBindings.Clear();
            dtpLahir.DataBindings.Clear();
            cbJnsKelamin.DataBindings.Clear();

            // PERBAIKAN: Tambahkan parameter formattingEnabled (true)
            // Ini sangat krusial agar kontrol seperti DateTimePicker bisa mengenali format data
            txtIDPasien.DataBindings.Add("Text", bindingSource, "id_pasien", true);
            txtNama.DataBindings.Add("Text", bindingSource, "nama_pasien", true);
            txtAlamat.DataBindings.Add("Text", bindingSource, "alamat", true);
            txtTelp.DataBindings.Add("Text", bindingSource, "no_telepon", true);

            // Binding khusus untuk DateTimePicker (properti 'Value')
            dtpLahir.DataBindings.Add("Value", bindingSource, "tanggal_lahir", true);

            // Binding untuk ComboBox (properti 'Text')
            cbJnsKelamin.DataBindings.Add("Text", bindingSource, "jenis_kelamin", true);
        }

        private void FormDashboardAdmin_Load(object sender, EventArgs e)
        {
        }
    }
}