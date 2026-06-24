using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            CrystalReport1 rd = new CrystalReport1();

            rd.SetDatabaseLogon("", "", @"(localdb)\MSSQLLocalDB", "klinik_db");

            crystalReportViewer2.ReportSource = rd;
            crystalReportViewer2.Refresh();
        }
    }
}
