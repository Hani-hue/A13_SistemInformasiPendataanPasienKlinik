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
    public partial class FormLihatDataPasienAdmin : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=klinik_db;Integrated Security=True";
        public FormLihatDataPasienAdmin()
        {
            InitializeComponent();
            TampilkanSemuaData();
        }

        private void TampilkanSemuaData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    //Perintah buat ambil kolom-kolom spesifik dari tabel pasien
                    string query = "SELECT id_pasien, nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin FROM pasien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Memuat Data: " + ex.Message);
                }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Mencari berdasarkan nama atau id_pasien
                    string query = "SELECT * FROM pasien WHERE nama_pasien LIKE @cari OR id_pasien LIKE @cari";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // 2. Simbol '%' artinya 'Wildcard'. 
                    // Kalau Isna ketik "Hab", dia bakal nyari "Habibah", "Habibi", dsb (depan/tengah/belakang)
                    cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%"); // txtCari adalah nama TextBox kamu

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    //Kalau datanya kosong (Count == 0), kasih tahu admin
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data pasien tidak ditemukan.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat mencari: " + ex.Message);
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            DashboardAdminNew menuUtama = new DashboardAdminNew();
            menuUtama.Show();
            this.Close(); // Tutup form lihat data
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLihatDataPasienAdmin_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection daftarNama = new AutoCompleteStringCollection();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Ambil id dan nama untuk saran pencarian
                    string query = "SELECT id_pasien, nama_pasien FROM pasien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Format tampilannya: "ID - Nama" (Contoh: "1 - Budi Santoso")
                        daftarNama.Add(reader["id_pasien"].ToString() + " - " + reader["nama_pasien"].ToString());
                    }

                    txtCari.AutoCompleteCustomSource = daftarNama;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data pencarian: " + ex.Message);
                }
            }
        }
    }
}
