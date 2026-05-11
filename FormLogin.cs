using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Wajib ada untuk koneksi database
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    public partial class Form1 : Form
    {
        // Gunakan server kamu
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=klinik_db;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ... (validasi username kosong tetap sama) ...

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SESUAIKAN: Tabelnya 'users' 
                    string query = "SELECT role FROM users WHERE username=@user AND password=@pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string role = reader["role"].ToString().Trim();

                        // INSERT kamu pakai 'admin' huruf kecil, jadi pakai OrdinalIgnoreCase biar aman
                        if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            DashboardAdminNew menuUtama = new DashboardAdminNew();
                            menuUtama.Show();
                            this.Hide();
                        }

                        //ini buat msauk ke dashboard dokter
                        else if (role.Equals("dokter", StringComparison.OrdinalIgnoreCase))
                        {
                            DashboardDokter menuDokter = new DashboardDokter();
                            menuDokter.Show();
                            this.Hide();
                        }
                    }

                    //pesan jika tidak menemukan pengguna yang benar
                    else
                    {
                        MessageBox.Show("Username atau Password salah!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Gagal Koneksi: " + ex.Message); }
            }
        }

    }
}
