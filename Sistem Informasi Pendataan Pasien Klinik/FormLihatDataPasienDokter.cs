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
    public partial class FormLihatDataPasienDokter : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=klinik_db;Integrated Security=True";
        public FormLihatDataPasienDokter()
        {
            InitializeComponent();
            TampilkanData(); // Fungsi ini langsung jalan ketika diklik supaya tabel tidak kosong saat dibuka
        }
      

        private void TampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    //Mengambil data identitas pasien dari database
                    string query = "SELECT id_pasien, nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin FROM pasien";

                    // SqlDataAdapter bertugas mengambil tabel dari database ke aplikasi
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable(); // Wadah tabel sementara di memori
                    adapter.Fill(dt); // Isi wadah dengan data
                    dataGridView1.DataSource = dt; // Tampilkan wadah ke tabel di layar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Memuat Data: " + ex.Message);
                }
            }
        }

        // --- TOMBOL CARI ---
        private void btnCari_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Mencari berdasarkan nama atau id_pasien
                    string query = "SELECT * FROM pasien WHERE nama_pasien LIKE @cari OR id_pasien LIKE @cari";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Simbol % digunakan agar pencarian fleksibel (depan, tengah, atau belakang)
                    cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // VALIDASI: Jika baris data yang ketemu adalah 0 (Zonk)
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data tidak ditemukan.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat mencari: " + ex.Message);
                }
            }
        }

        // --- TOMBOL KEMBALI ---
        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Kembali ke Dashboard Dokter
            // Pastikan nama form dashboard dokter kamu sudah benar
            DashboardDokter menuDokter = new DashboardDokter();
            menuDokter.Show();
            this.Close();
        }

    }
}
