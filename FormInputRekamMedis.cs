using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;

namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    public partial class FormInputRekamMedis : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=klinik_db;Integrated Security=True";
        DataTable dtExcel = new DataTable();
        private BindingSource bindingSource = new BindingSource();

        public FormInputRekamMedis()
        {
            InitializeComponent();
        }

        private void FormInputRekamMedis_Load(object sender, EventArgs e)
        {
            TampilkanDataTabel();
        }

        private void TampilkanDataTabel()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllRekamMedis", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    bindingNavigator1.BindingSource = bindingSource;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Load Tabel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO rekam_medis (id_pasien, id_dokter, tanggal_pemeriksaan, keluhan, diagnosa, tindakan) 
                                     VALUES (@namaP, @namaD, @tgl, @kel, @diag, @tind)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@namaP", SqlDbType.NVarChar).Value = txtPasien.Text;
                    cmd.Parameters.Add("@namaD", SqlDbType.NVarChar).Value = txtIDokter.Text;
                    cmd.Parameters.AddWithValue("@tgl", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@kel", txtKeluhan.Text);
                    cmd.Parameters.AddWithValue("@diag", txtDiagnosa.Text);
                    cmd.Parameters.AddWithValue("@tind", txtTindakan.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Berhasil Disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanDataTabel();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Masih ada kendala: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            DashboardDokter menu = new DashboardDokter();
            menu.Show();
            this.Close();
        }

        private void btnImporExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx";
            ofd.Title = "Pilih File Excel";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            dtExcel = result.Tables[0];
                            bindingSource.DataSource = dtExcel;
                            dataGridView1.DataSource = bindingSource;
                            bindingNavigator1.BindingSource = bindingSource;
                            MessageBox.Show($"Berhasil membaca {dtExcel.Rows.Count} baris data dari Excel!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal baca Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImporDb_Click(object sender, EventArgs e)
        {
            if (dtExcel == null || dtExcel.Rows.Count == 0)
            {
                MessageBox.Show("Import Excel dulu sebelum ke database!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int berhasil = 0;

                    foreach (DataRow row in dtExcel.Rows)
                    {
                        try
                        {
                            string query = @"INSERT INTO rekam_medis 
                                            (id_pasien, id_dokter, tanggal_pemeriksaan, keluhan, diagnosa, tindakan)
                                            VALUES (@namaP, @namaD, @tgl, @kel, @diag, @tind)";

                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.Add("@namaP", SqlDbType.NVarChar).Value = row["nama_pasien"].ToString();
                            cmd.Parameters.Add("@namaD", SqlDbType.NVarChar).Value = row["nama_dokter"].ToString();
                            cmd.Parameters.Add("@tgl", SqlDbType.DateTime).Value = Convert.ToDateTime(row["tanggal_pemeriksaan"]);
                            cmd.Parameters.Add("@kel", SqlDbType.NVarChar).Value = row["keluhan"].ToString();
                            cmd.Parameters.Add("@diag", SqlDbType.NVarChar).Value = row["diagnosa"].ToString();
                            cmd.Parameters.Add("@tind", SqlDbType.NVarChar).Value = row["tindakan"].ToString();

                            cmd.ExecuteNonQuery();
                            berhasil++;
                        }
                        catch { }
                    }

                    MessageBox.Show($"{berhasil} data berhasil diimport ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanDataTabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal import ke database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLihatReport_Click(object sender, EventArgs e)
        {
            FormReport fr = new FormReport();
            fr.Show();
        }

        private void txtPasien_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
    }
}