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
    public partial class FormInputRekamMedis : Form
    {
        string connectionString = @"Data Source=HANI1104\HANIW;Initial Catalog=klinik_db;Integrated Security=True";
        public FormInputRekamMedis()
        {
            InitializeComponent();
        }

        private void TampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Tabel hanya menampilkan ID saja sesuai request kamu
                    string query = "SELECT id_rekam, id_pasien, id_dokter, tanggal_pemeriksaan, diagnosa, tindakan FROM rekam_medis";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Gagal Load Tabel: " + ex.Message); }
            }
        }

        
    }
}
