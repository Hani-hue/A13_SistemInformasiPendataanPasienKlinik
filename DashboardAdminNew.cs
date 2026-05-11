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

        private void btnPasien_Click(object sender, EventArgs e)
        {
            FormDashboardAdmin formKelola = new FormDashboardAdmin();
            formKelola.Show();
            this.Hide();
        }

        private void btnLihat_Click(object sender, EventArgs e)
        {
            FormLihatDataPasienAdmin lihatData = new FormLihatDataPasienAdmin();
            lihatData.Show();
            this.Hide();
        }

        // FUNGSI LOGOUT - Gunakan yang ini
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Close(); // Menutup Dashboard dan kembali ke Login
        }

        private void DashboardAdminNew_Load(object sender, EventArgs e)
        {
            // Kosongkan saja
        }

        private void label1_Click(object sender, EventArgs e) { }

        // Fungsi btnLogOut_Click_1 dihapus saja supaya tidak double
    }
}
