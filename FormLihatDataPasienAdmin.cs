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
        private BindingSource bindingSource = new BindingSource();

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

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    bindingNavigator1.BindingSource = bindingSource;
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
                    string query = "SELECT * FROM pasien WHERE nama_pasien LIKE @cari OR CAST(id_pasien AS VARCHAR) LIKE @cari";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    bindingNavigator1.BindingSource = bindingSource;

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
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void txtCari_TextChanged(object sender, EventArgs e) { }

        private void FormLihatDataPasienAdmin_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection daftarNama = new AutoCompleteStringCollection();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_pasien, nama_pasien FROM pasien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
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

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e) { }
    }
}