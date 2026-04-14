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

        // --- FUNGSI VERIFIKASI ID PASIEN ---
        private bool ApakahPasienAda(string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM pasien WHERE id_pasien = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Mengembalikan true jika ID ditemukan
            }
        }

        // --- TOMBOL SIMPAN ---
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // 1. Validasi input kosong
            if (string.IsNullOrWhiteSpace(txtIDPasien.Text) || string.IsNullOrWhiteSpace(txtIDokter.Text))
            {
                MessageBox.Show("ID Pasien dan ID Dokter tidak boleh kosong!");
                return;
            }

            // 2. VERIFIKASI: Cek apakah ID Pasien ada di database
            if (!ApakahPasienAda(txtIDPasien.Text))
            {
                MessageBox.Show("Gagal! ID Pasien '" + txtIDPasien.Text + "' tidak terdaftar di sistem.", "Error Verifikasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDPasien.Focus();
                return; // Berhenti di sini, tidak lanjut simpan
            }

            // 3. Jika lolos verifikasi, baru simpan
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO rekam_medis (id_pasien, id_dokter, tanggal_pemeriksaan, keluhan, diagnosa, tindakan) 
                                     VALUES (@idP, @idD, @tgl, @kel, @diag, @tind)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idP", txtIDPasien.Text);
                    cmd.Parameters.AddWithValue("@idD", txtIDokter.Text);
                    cmd.Parameters.AddWithValue("@tgl", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@kel", txtKeluhan.Text);
                    cmd.Parameters.AddWithValue("@diag", txtDiagnosa.Text);
                    cmd.Parameters.AddWithValue("@tind", txtTindakan.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Rekam Medis Berhasil Disimpan!", "Sukses");
                    ClearForm();
                    TampilkanData();
                }
                catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            DashboardDokter menu = new DashboardDokter();
            menu.Show();
            this.Close();
        }

        private void ClearForm()
        {
            txtIDPasien.Clear();
            txtIDokter.Clear();
            txtKeluhan.Clear();
            txtDiagnosa.Clear();
            txtTindakan.Clear();
            dtpTanggal.Value = DateTime.Now;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
