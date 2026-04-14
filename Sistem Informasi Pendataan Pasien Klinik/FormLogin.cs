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
        string connectionString = @"Data Source=HANI1104\HANIW;Initial Catalog=klinik_db;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

    }
}
