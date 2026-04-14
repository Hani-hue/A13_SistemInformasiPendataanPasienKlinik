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
        string connectionString = @"Data Source=HANI1104\HANIW;Initial Catalog=klinik_db;Integrated Security=True";
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

        
    }
}
