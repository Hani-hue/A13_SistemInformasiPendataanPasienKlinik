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

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // BAGIAN F: Validasi Input agar tidak kosong
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("Nama dan Alamat tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO Pasien (nama_pasien, alamat, no_telepon, tanggal_lahir, jenis_kelamin) " + " VALUES (@nama, @alamat, @telp, @tgl, @jk)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@telp", txtTelp.Text);
                    cmd.Parameters.AddWithValue("@tgl", dtpLahir.Value);
                    cmd.Parameters.AddWithValue("@jk", cbJnsKelamin.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Pasien Berhasil Disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm(); // Bersihkan textbox setelah simpan
                    TampilkanData(); // Refresh tabel
                }
                catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDPasien.Text))
            {
                MessageBox.Show("Pilih data yang ingin diubah dari tabel terlebih dahulu!");
                return;
            }

            // BAGIAN F: Konfirmasi sebelum ubah
            if (MessageBox.Show("Yakin ingin mengubah data ini?", "Konfirmasi Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        string query = "UPDATE Pasien SET nama_pasien=@nama, alamat=@alamat, no_telepon=@telp, tanggal_lahir=@tgl, jenis_kelamin=@jk WHERE id_pasien=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", txtIDPasien.Text);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                        cmd.Parameters.AddWithValue("@telp", txtTelp.Text);
                        cmd.Parameters.AddWithValue("@tgl", dtpLahir.Value);
                        cmd.Parameters.AddWithValue("@jk", cbJnsKelamin.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Diperbarui!");
                        TampilkanData();
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
                }
            }
        }




    }
}