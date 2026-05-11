namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    partial class FormInputRekamMedis
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKembali = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTindakan = new System.Windows.Forms.MaskedTextBox();
            this.txtDiagnosa = new System.Windows.Forms.MaskedTextBox();
            this.txtKeluhan = new System.Windows.Forms.MaskedTextBox();
            this.txtIDokter = new System.Windows.Forms.MaskedTextBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.cmbPasien = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 361);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(569, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(642, 471);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(135, 40);
            this.btnKembali.TabIndex = 2;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(642, 37);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(135, 40);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Simpan Data";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nama Pasien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nama Dokter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tanggal Periksa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Keluhan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Diagnosa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tindakan";
            // 
            // txtTindakan
            // 
            this.txtTindakan.Location = new System.Drawing.Point(190, 215);
            this.txtTindakan.Name = "txtTindakan";
            this.txtTindakan.Size = new System.Drawing.Size(144, 26);
            this.txtTindakan.TabIndex = 14;
            // 
            // txtDiagnosa
            // 
            this.txtDiagnosa.Location = new System.Drawing.Point(190, 183);
            this.txtDiagnosa.Name = "txtDiagnosa";
            this.txtDiagnosa.Size = new System.Drawing.Size(144, 26);
            this.txtDiagnosa.TabIndex = 15;
            // 
            // txtKeluhan
            // 
            this.txtKeluhan.Location = new System.Drawing.Point(190, 148);
            this.txtKeluhan.Name = "txtKeluhan";
            this.txtKeluhan.Size = new System.Drawing.Size(144, 26);
            this.txtKeluhan.TabIndex = 16;
            // 
            // txtIDokter
            // 
            this.txtIDokter.Location = new System.Drawing.Point(190, 77);
            this.txtIDokter.Name = "txtIDokter";
            this.txtIDokter.Size = new System.Drawing.Size(144, 26);
            this.txtIDokter.TabIndex = 18;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(190, 111);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 26);
            this.dtpTanggal.TabIndex = 19;
            // 
            // cmbPasien
            // 
            this.cmbPasien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPasien.FormattingEnabled = true;
            this.cmbPasien.Location = new System.Drawing.Point(190, 37);
            this.cmbPasien.Name = "cmbPasien";
            this.cmbPasien.Size = new System.Drawing.Size(121, 28);
            this.cmbPasien.TabIndex = 20;
            // 
            // FormInputRekamMedis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.cmbPasien);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.txtIDokter);
            this.Controls.Add(this.txtKeluhan);
            this.Controls.Add(this.txtDiagnosa);
            this.Controls.Add(this.txtTindakan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormInputRekamMedis";
            this.Text = "FormInputRekamMedis";
            this.Load += new System.EventHandler(this.FormInputRekamMedis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtTindakan;
        private System.Windows.Forms.MaskedTextBox txtDiagnosa;
        private System.Windows.Forms.MaskedTextBox txtKeluhan;
        private System.Windows.Forms.MaskedTextBox txtIDokter;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.ComboBox cmbPasien;
    }
}