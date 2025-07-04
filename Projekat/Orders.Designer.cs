namespace Projekat
{
    partial class Orders
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
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlOrderDetails = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.lblCenaValue = new System.Windows.Forms.Label();
            this.lblAdresaValue = new System.Windows.Forms.Label();
            this.lblDatumValue = new System.Windows.Forms.Label();
            this.lblKupacValue = new System.Windows.Forms.Label();
            this.lblNarudzbinaValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCena = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblKupac = new System.Windows.Forms.Label();
            this.lblNarudzbina = new System.Windows.Forms.Label();
            this.btnOpenArch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(828, 447);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // btnArchive
            // 
            this.btnArchive.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Location = new System.Drawing.Point(105, 521);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(108, 41);
            this.btnArchive.TabIndex = 5;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(354, 521);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 41);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlOrderDetails
            // 
            this.pnlOrderDetails.Controls.Add(this.dataGridView2);
            this.pnlOrderDetails.Controls.Add(this.statusCbx);
            this.pnlOrderDetails.Controls.Add(this.btnClose);
            this.pnlOrderDetails.Controls.Add(this.btnPrint);
            this.pnlOrderDetails.Controls.Add(this.btnChangeStatus);
            this.pnlOrderDetails.Controls.Add(this.lblCenaValue);
            this.pnlOrderDetails.Controls.Add(this.lblAdresaValue);
            this.pnlOrderDetails.Controls.Add(this.lblDatumValue);
            this.pnlOrderDetails.Controls.Add(this.lblKupacValue);
            this.pnlOrderDetails.Controls.Add(this.lblNarudzbinaValue);
            this.pnlOrderDetails.Controls.Add(this.lblStatus);
            this.pnlOrderDetails.Controls.Add(this.lblCena);
            this.pnlOrderDetails.Controls.Add(this.lblAdresa);
            this.pnlOrderDetails.Controls.Add(this.lblDatum);
            this.pnlOrderDetails.Controls.Add(this.lblKupac);
            this.pnlOrderDetails.Controls.Add(this.lblNarudzbina);
            this.pnlOrderDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOrderDetails.Location = new System.Drawing.Point(846, 0);
            this.pnlOrderDetails.Name = "pnlOrderDetails";
            this.pnlOrderDetails.Size = new System.Drawing.Size(372, 638);
            this.pnlOrderDetails.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 276);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(309, 221);
            this.dataGridView2.TabIndex = 35;
            // 
            // statusCbx
            // 
            this.statusCbx.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Location = new System.Drawing.Point(183, 230);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(130, 31);
            this.statusCbx.TabIndex = 34;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(123, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 41);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close Details";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(209, 521);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(118, 41);
            this.btnPrint.TabIndex = 31;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeStatus.Location = new System.Drawing.Point(22, 521);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(135, 41);
            this.btnChangeStatus.TabIndex = 9;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // lblCenaValue
            // 
            this.lblCenaValue.AutoSize = true;
            this.lblCenaValue.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenaValue.Location = new System.Drawing.Point(179, 180);
            this.lblCenaValue.Name = "lblCenaValue";
            this.lblCenaValue.Size = new System.Drawing.Size(48, 23);
            this.lblCenaValue.TabIndex = 29;
            this.lblCenaValue.Text = "Value";
            // 
            // lblAdresaValue
            // 
            this.lblAdresaValue.AutoSize = true;
            this.lblAdresaValue.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresaValue.Location = new System.Drawing.Point(179, 133);
            this.lblAdresaValue.Name = "lblAdresaValue";
            this.lblAdresaValue.Size = new System.Drawing.Size(48, 23);
            this.lblAdresaValue.TabIndex = 28;
            this.lblAdresaValue.Text = "Value";
            // 
            // lblDatumValue
            // 
            this.lblDatumValue.AutoSize = true;
            this.lblDatumValue.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumValue.Location = new System.Drawing.Point(179, 92);
            this.lblDatumValue.Name = "lblDatumValue";
            this.lblDatumValue.Size = new System.Drawing.Size(48, 23);
            this.lblDatumValue.TabIndex = 27;
            this.lblDatumValue.Text = "Value";
            // 
            // lblKupacValue
            // 
            this.lblKupacValue.AutoSize = true;
            this.lblKupacValue.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupacValue.Location = new System.Drawing.Point(179, 49);
            this.lblKupacValue.Name = "lblKupacValue";
            this.lblKupacValue.Size = new System.Drawing.Size(48, 23);
            this.lblKupacValue.TabIndex = 26;
            this.lblKupacValue.Text = "Value";
            // 
            // lblNarudzbinaValue
            // 
            this.lblNarudzbinaValue.AutoSize = true;
            this.lblNarudzbinaValue.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarudzbinaValue.Location = new System.Drawing.Point(179, 9);
            this.lblNarudzbinaValue.Name = "lblNarudzbinaValue";
            this.lblNarudzbinaValue.Size = new System.Drawing.Size(48, 23);
            this.lblNarudzbinaValue.TabIndex = 25;
            this.lblNarudzbinaValue.Text = "Value";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(14, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 23);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Status:";
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCena.Location = new System.Drawing.Point(14, 180);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(104, 23);
            this.lblCena.TabIndex = 23;
            this.lblCena.Text = "Ukupna cena:";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresa.Location = new System.Drawing.Point(14, 133);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(126, 23);
            this.lblAdresa.TabIndex = 22;
            this.lblAdresa.Text = "Adresa isporuke:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(14, 92);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(143, 23);
            this.lblDatum.TabIndex = 21;
            this.lblDatum.Text = "Datum narudzbine:";
            // 
            // lblKupac
            // 
            this.lblKupac.AutoSize = true;
            this.lblKupac.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupac.Location = new System.Drawing.Point(14, 49);
            this.lblKupac.Name = "lblKupac";
            this.lblKupac.Size = new System.Drawing.Size(56, 23);
            this.lblKupac.TabIndex = 20;
            this.lblKupac.Text = "Kupac:";
            // 
            // lblNarudzbina
            // 
            this.lblNarudzbina.AutoSize = true;
            this.lblNarudzbina.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarudzbina.Location = new System.Drawing.Point(14, 9);
            this.lblNarudzbina.Name = "lblNarudzbina";
            this.lblNarudzbina.Size = new System.Drawing.Size(114, 23);
            this.lblNarudzbina.TabIndex = 19;
            this.lblNarudzbina.Text = "Narudzbina ID:";
            // 
            // btnOpenArch
            // 
            this.btnOpenArch.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenArch.Location = new System.Drawing.Point(603, 521);
            this.btnOpenArch.Name = "btnOpenArch";
            this.btnOpenArch.Size = new System.Drawing.Size(131, 41);
            this.btnOpenArch.TabIndex = 9;
            this.btnOpenArch.Text = "Open archive";
            this.btnOpenArch.UseVisualStyleBackColor = true;
            this.btnOpenArch.Click += new System.EventHandler(this.btnOpenArch_Click);
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 638);
            this.Controls.Add(this.btnOpenArch);
            this.Controls.Add(this.pnlOrderDetails);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Orders";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Orders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlOrderDetails.ResumeLayout(false);
            this.pnlOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlOrderDetails;
        private System.Windows.Forms.Label lblNarudzbina;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblKupac;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Label lblCenaValue;
        private System.Windows.Forms.Label lblAdresaValue;
        private System.Windows.Forms.Label lblDatumValue;
        private System.Windows.Forms.Label lblKupacValue;
        private System.Windows.Forms.Label lblNarudzbinaValue;
        private System.Windows.Forms.ComboBox statusCbx;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnOpenArch;
    }
}