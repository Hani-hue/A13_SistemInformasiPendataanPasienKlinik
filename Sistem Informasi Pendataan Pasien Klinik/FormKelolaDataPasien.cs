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
        // Alamat database kamu
        string connectionString = @"Data Source=HANI1104\HANIW;Initial Catalog=klinik_db;Integrated Security=True";

        public FormDashboardAdmin()
        {
            InitializeComponent();
            TampilkanData(); // Memanggil data otomatis saat form terbuka
        }

        // --- BAGIAN E: TAMPILKAN DATA & BAGIAN D: EXECUTE SCALAR ---
        private void TampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // PENGAMAN: Buka koneksi di awal blok try
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = "SELECT id_pasien, nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin FROM pasien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPasien.DataSource = dt;

                    // BAGIAN D: Menghitung jumlah record menggunakan ExecuteScalar
                    SqlCommand cmdSum = new SqlCommand("SELECT COUNT(*) FROM pasien", conn);
                    label1.Text = "Total Pasien: " + cmdSum.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Memuat Data: " + ex.Message);
                }
            }
        }

    }
}