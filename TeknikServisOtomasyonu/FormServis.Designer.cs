namespace TeknikServisOtomasyonu
{
    partial class FormServis
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
            this.dgvArizalar = new System.Windows.Forms.DataGridView();
            this.lblArizaID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIslem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIscilik = new System.Windows.Forms.TextBox();
            this.btnIslemEkle = new System.Windows.Forms.Button();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.btnBitir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArizalar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "BEKLEYEN CİHAZLAR:";
            // 
            // dgvArizalar
            // 
            this.dgvArizalar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.dgvArizalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArizalar.Location = new System.Drawing.Point(260, 16);
            this.dgvArizalar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvArizalar.Name = "dgvArizalar";
            this.dgvArizalar.RowHeadersWidth = 51;
            this.dgvArizalar.Size = new System.Drawing.Size(697, 185);
            this.dgvArizalar.TabIndex = 1;
            this.dgvArizalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArizalar_CellClick);
            this.dgvArizalar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArizalar_CellContentClick);
            // 
            // lblArizaID
            // 
            this.lblArizaID.AutoSize = true;
            this.lblArizaID.Location = new System.Drawing.Point(17, 505);
            this.lblArizaID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArizaID.Name = "lblArizaID";
            this.lblArizaID.Size = new System.Drawing.Size(11, 16);
            this.lblArizaID.TabIndex = 2;
            this.lblArizaID.Text = "-";
            this.lblArizaID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "YAPILAN İŞLEM:";
            // 
            // txtIslem
            // 
            this.txtIslem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.txtIslem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIslem.Location = new System.Drawing.Point(173, 316);
            this.txtIslem.Margin = new System.Windows.Forms.Padding(4);
            this.txtIslem.Multiline = true;
            this.txtIslem.Name = "txtIslem";
            this.txtIslem.Size = new System.Drawing.Size(132, 24);
            this.txtIslem.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(21, 368);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "PARÇA ÜCRETİ:";
            // 
            // txtParca
            // 
            this.txtParca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.txtParca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParca.Location = new System.Drawing.Point(173, 371);
            this.txtParca.Margin = new System.Windows.Forms.Padding(4);
            this.txtParca.Name = "txtParca";
            this.txtParca.Size = new System.Drawing.Size(132, 22);
            this.txtParca.TabIndex = 6;
            this.txtParca.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(372, 368);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "İŞÇİLİK ÜCRETİ:";
            // 
            // txtIscilik
            // 
            this.txtIscilik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.txtIscilik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIscilik.Location = new System.Drawing.Point(522, 371);
            this.txtIscilik.Margin = new System.Windows.Forms.Padding(4);
            this.txtIscilik.Name = "txtIscilik";
            this.txtIscilik.Size = new System.Drawing.Size(132, 22);
            this.txtIscilik.TabIndex = 8;
            this.txtIscilik.Text = "0";
            // 
            // btnIslemEkle
            // 
            this.btnIslemEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.btnIslemEkle.FlatAppearance.BorderSize = 0;
            this.btnIslemEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIslemEkle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIslemEkle.Location = new System.Drawing.Point(173, 436);
            this.btnIslemEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnIslemEkle.Name = "btnIslemEkle";
            this.btnIslemEkle.Size = new System.Drawing.Size(108, 49);
            this.btnIslemEkle.TabIndex = 9;
            this.btnIslemEkle.Text = "İŞLEM EKLE";
            this.btnIslemEkle.UseVisualStyleBackColor = false;
            this.btnIslemEkle.Click += new System.EventHandler(this.btnIslemEkle_Click);
            // 
            // btnHesapla
            // 
            this.btnHesapla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.btnHesapla.FlatAppearance.BorderSize = 0;
            this.btnHesapla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHesapla.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapla.Location = new System.Drawing.Point(360, 436);
            this.btnHesapla.Margin = new System.Windows.Forms.Padding(4);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(116, 49);
            this.btnHesapla.TabIndex = 10;
            this.btnHesapla.Text = "BORÇ HESAPLA";
            this.btnHesapla.UseVisualStyleBackColor = false;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // btnBitir
            // 
            this.btnBitir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(137)))), ((int)(((byte)(147)))));
            this.btnBitir.FlatAppearance.BorderSize = 0;
            this.btnBitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitir.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBitir.Location = new System.Drawing.Point(557, 436);
            this.btnBitir.Margin = new System.Windows.Forms.Padding(4);
            this.btnBitir.Name = "btnBitir";
            this.btnBitir.Size = new System.Drawing.Size(129, 48);
            this.btnBitir.TabIndex = 11;
            this.btnBitir.Text = "SERVİSİ TAMAMLA";
            this.btnBitir.UseVisualStyleBackColor = false;
            this.btnBitir.Click += new System.EventHandler(this.btnBitir_Click);
            // 
            // FormServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1432, 554);
            this.Controls.Add(this.btnBitir);
            this.Controls.Add(this.btnHesapla);
            this.Controls.Add(this.btnIslemEkle);
            this.Controls.Add(this.txtIscilik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtParca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIslem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblArizaID);
            this.Controls.Add(this.dgvArizalar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormServis";
            this.Text = "FormServis";
            this.Load += new System.EventHandler(this.FormServis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArizalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvArizalar;
        private System.Windows.Forms.Label lblArizaID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIslem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIscilik;
        private System.Windows.Forms.Button btnIslemEkle;
        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.Button btnBitir;
    }
}