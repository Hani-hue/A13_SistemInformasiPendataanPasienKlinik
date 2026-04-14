namespace Sistem_Informasi_Pendataan_Pasien_Klinik
{
    partial class FormDashboardAdmin
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
            this.dgvPasien = new System.Windows.Forms.DataGridView();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtIDPasien = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtTelp = new System.Windows.Forms.TextBox();
            this.dtpLahir = new System.Windows.Forms.DateTimePicker();
            this.cbJnsKelamin = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKembali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPasien
            // 
            this.dgvPasien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasien.Location = new System.Drawing.Point(12, 338);
            this.dgvPasien.Name = "dgvPasien";
            this.dgvPasien.RowHeadersWidth = 62;
            this.dgvPasien.RowTemplate.Height = 28;
            this.dgvPasien.Size = new System.Drawing.Size(679, 194);
            this.dgvPasien.TabIndex = 0;
            this.dgvPasien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasien_CellClick);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(12, 66);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(100, 26);
            this.txtNama.TabIndex = 1;
            // 
            // txtIDPasien
            // 
            this.txtIDPasien.Location = new System.Drawing.Point(12, 25);
            this.txtIDPasien.Name = "txtIDPasien";
            this.txtIDPasien.Size = new System.Drawing.Size(100, 26);
            this.txtIDPasien.TabIndex = 2;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(12, 113);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(100, 26);
            this.txtAlamat.TabIndex = 3;
            // 
            // txtTelp
            // 
            this.txtTelp.Location = new System.Drawing.Point(12, 162);
            this.txtTelp.Name = "txtTelp";
            this.txtTelp.Size = new System.Drawing.Size(100, 26);
            this.txtTelp.TabIndex = 4;
            // 
            // dtpLahir
            // 
            this.dtpLahir.Location = new System.Drawing.Point(201, 23);
            this.dtpLahir.Name = "dtpLahir";
            this.dtpLahir.Size = new System.Drawing.Size(200, 26);
            this.dtpLahir.TabIndex = 6;
            // 
            // cbJnsKelamin
            // 
            this.cbJnsKelamin.FormattingEnabled = true;
            this.cbJnsKelamin.Location = new System.Drawing.Point(201, 64);
            this.cbJnsKelamin.Name = "cbJnsKelamin";
            this.cbJnsKelamin.Size = new System.Drawing.Size(121, 28);
            this.cbJnsKelamin.TabIndex = 7;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(575, 25);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(137, 43);
            this.btnSimpan.TabIndex = 8;
            this.btnSimpan.Text = "Tambah Data";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(729, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 43);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update Data";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(575, 83);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(137, 43);
            this.btnHapus.TabIndex = 10;
            this.btnHapus.Text = "Hapus Data";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(729, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 43);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Clear All Data";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(709, 472);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(137, 43);
            this.btnKembali.TabIndex = 14;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // FormDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.cbJnsKelamin);
            this.Controls.Add(this.dtpLahir);
            this.Controls.Add(this.txtTelp);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtIDPasien);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.dgvPasien);
            this.Name = "FormDashboardAdmin";
            this.Text = "Kelola Data Pasien";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPasien;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtIDPasien;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtTelp;
        private System.Windows.Forms.DateTimePicker dtpLahir;
        private System.Windows.Forms.ComboBox cbJnsKelamin;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKembali;
    }
}