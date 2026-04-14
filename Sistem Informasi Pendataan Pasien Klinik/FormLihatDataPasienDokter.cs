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
        string connectionString = @"Data Source=HANI1104\HANIW;Initial Catalog=klinik_db;Integrated Security=True";
        public FormLihatDataPasienDokter()
        {
            InitializeComponent();
            TampilkanData();
        }

        private void TampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
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
                    cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

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
