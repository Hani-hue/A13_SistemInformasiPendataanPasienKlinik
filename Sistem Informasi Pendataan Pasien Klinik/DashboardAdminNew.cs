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

    }
}
