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
    public partial class DashboardDokter : Form
    {
        public DashboardDokter()
        {
            InitializeComponent();
        }

        private void btnLihat_Click(object sender, EventArgs e)
        {
            // Membuka form yang isinya tabel data pasien (hanya lihat)
            // Pastikan kamu sudah buat form bernama FormLihatDataPasienAdmin atau sejenisnya
            FormLihatDataPasienDokter lihatData = new FormLihatDataPasienDokter();
            lihatData.Show();
            this.Hide();
        }

        // 2. Tombol Isi Rekam Medis
        private void btnIsiRekam_Click(object sender, EventArgs e)
        {
            // Membuka form untuk input rekam medis (diagnosa, tindakan, dll)
            // Pastikan kamu punya Form bernama FormRekamMedis
            FormInputRekamMedis inputRM = new FormInputRekamMedis();
            inputRM.Show();
            this.Hide();
        }

        // 3. Tombol Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Kembali ke Form Login
            Form1 login = new Form1();
            login.Show();
            this.Close(); // Menutup Dashboard Dokter
        }
    }
}
