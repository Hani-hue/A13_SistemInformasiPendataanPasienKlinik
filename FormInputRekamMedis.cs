using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    public partial class FormInputRekamMedis : Form
    {
        // Connection string - pastikan sesuai dengan server kamu
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=klinik_db;Integrated Security=True";

        public FormInputRekamMedis()
        {
            InitializeComponent();
        }

        private void FormInputRekamMedis_Load(object sender, EventArgs e)
        {
            LoadDataPasien();
            TampilkanDataTabel();
        }

        // Mengisi ComboBox Pasien dengan Nama
        private void LoadDataPasien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT nama_pasien FROM pasien";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPasien.DataSource = dt;
                    cmbPasien.DisplayMember = "nama_pasien";
                }
                catch (Exception ex) { MessageBox.Show("Gagal Load Pasien: " + ex.Message); }
            }
        }

        // Menampilkan data rekam medis di DataGridView
        private void TampilkanDataTabel()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM rekam_medis";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Gagal Load Tabel: " + ex.Message); }
            }
        }

        // TOMBOL SIMPAN - Sekarang kirim Nama, bukan ID!
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO rekam_medis (id_pasien, id_dokter, tanggal_pemeriksaan, keluhan, diagnosa, tindakan) 
                             VALUES (@namaP, @namaD, @tgl, @kel, @diag, @tind)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // --- BAGIAN PERBAIKAN ---
                    // Gunakan .GetItemText agar yang diambil adalah tulisan "Budi Santoso", 
                    // bukan "System.Data.DataRowView"
                    string namaPasienFix = cmbPasien.GetItemText(cmbPasien.SelectedItem);

                    cmd.Parameters.Add("@namaP", SqlDbType.NVarChar).Value = namaPasienFix;
                    cmd.Parameters.Add("@namaD", SqlDbType.NVarChar).Value = txtIDokter.Text;
                    // ------------------------

                    cmd.Parameters.AddWithValue("@tgl", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@kel", txtKeluhan.Text);
                    cmd.Parameters.AddWithValue("@diag", txtDiagnosa.Text);
                    cmd.Parameters.AddWithValue("@tind", txtTindakan.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Alhamdulillah Berhasil! Sekarang namanya muncul dengan benar.", "Sukses");

                    TampilkanDataTabel();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Masih ada kendala: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtIDokter.Clear();
            txtKeluhan.Clear();
            txtDiagnosa.Clear();
            txtTindakan.Clear();
            dtpTanggal.Value = DateTime.Now;
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            DashboardDokter menu = new DashboardDokter();
            menu.Show();
            this.Close();
        }
    }
}