namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    partial class DashboardDokter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLihat = new System.Windows.Forms.Button();
            this.btnIsiRekam = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "dashboard Dokter";
            // 
            // btnLihat
            // 
            this.btnLihat.Location = new System.Drawing.Point(104, 342);
            this.btnLihat.Name = "btnLihat";
            this.btnLihat.Size = new System.Drawing.Size(189, 46);
            this.btnLihat.TabIndex = 1;
            this.btnLihat.Text = "Lihat data pasien";
            this.btnLihat.UseVisualStyleBackColor = true;
            this.btnLihat.Click += new System.EventHandler(this.btnLihat_Click);
            // 
            // btnIsiRekam
            // 
            this.btnIsiRekam.Location = new System.Drawing.Point(358, 342);
            this.btnIsiRekam.Name = "btnIsiRekam";
            this.btnIsiRekam.Size = new System.Drawing.Size(189, 46);
            this.btnIsiRekam.TabIndex = 2;
            this.btnIsiRekam.Text = "Isi Rekam Medis";
            this.btnIsiRekam.UseVisualStyleBackColor = true;
            this.btnIsiRekam.Click += new System.EventHandler(this.btnIsiRekam_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(608, 342);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(189, 46);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // DashboardDokter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 521);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnIsiRekam);
            this.Controls.Add(this.btnLihat);
            this.Controls.Add(this.label1);
            this.Name = "DashboardDokter";
            this.Text = "DashboardDokter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLihat;
        private System.Windows.Forms.Button btnIsiRekam;
        private System.Windows.Forms.Button btnLogout;
    }
}