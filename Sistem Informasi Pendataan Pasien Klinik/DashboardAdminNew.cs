using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    public partial class DashboardAdminNew : Form
    {
        public DashboardAdminNew()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnPasien_Click(object sender, EventArgs e)
        {
            // Pastikan nama FormDashboardAdmin sudah sesuai dengan file CRUD kamu
            FormDashboardAdmin formKelola = new FormDashboardAdmin();
            formKelola.Show();
            this.Hide(); // Sembunyikan menu utama
        }

        // 2. Tombol Lihat Data Pasien
        private void btnLihat_Click(object sender, EventArgs e)
        {
            FormLihatDataPasienAdmin lihatData = new FormLihatDataPasienAdmin();
            lihatData.Show();
            this.Hide();
        }

        // 3. Tombol Logout
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Kembali ke Form Login (Form1)
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close(); // Tutup Menu Utama
        }

        private void DashboardAdminNew_Load(object sender, EventArgs e)
        {

        }
    }
}
