namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    partial class DashboardAdminNew
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
            this.btnPasien = new System.Windows.Forms.Button();
            this.btnLihat = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPasien
            // 
            this.btnPasien.Location = new System.Drawing.Point(76, 300);
            this.btnPasien.Name = "btnPasien";
            this.btnPasien.Size = new System.Drawing.Size(206, 46);
            this.btnPasien.TabIndex = 0;
            this.btnPasien.Text = "Kelola Data Pasien";
            this.btnPasien.UseVisualStyleBackColor = true;
            this.btnPasien.Click += new System.EventHandler(this.btnPasien_Click);
            // 
            // btnLihat
            // 
            this.btnLihat.Location = new System.Drawing.Point(316, 300);
            this.btnLihat.Name = "btnLihat";
            this.btnLihat.Size = new System.Drawing.Size(194, 45);
            this.btnLihat.TabIndex = 1;
            this.btnLihat.Text = "Lihat Data Pasien ";
            this.btnLihat.UseVisualStyleBackColor = true;
            this.btnLihat.Click += new System.EventHandler(this.btnLihat_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(554, 301);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(194, 45);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dashboard Admin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DashboardAdminNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLihat);
            this.Controls.Add(this.btnPasien);
            this.Name = "DashboardAdminNew";
            this.Text = "DashboardAdminNew";
            this.Load += new System.EventHandler(this.DashboardAdminNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPasien;
        private System.Windows.Forms.Button btnLihat;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label1;
    }
}