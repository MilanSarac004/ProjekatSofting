namespace Projekat
{
    partial class Users
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idTB = new System.Windows.Forms.TextBox();
            this.imeTB = new System.Windows.Forms.TextBox();
            this.prezimeTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.passTB = new System.Windows.Forms.TextBox();
            this.drzavaTB = new System.Windows.Forms.TextBox();
            this.gradTB = new System.Windows.Forms.TextBox();
            this.adresaTB = new System.Windows.Forms.TextBox();
            this.telefonTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.adminCB = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(698, 545);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 41);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdate.Location = new System.Drawing.Point(833, 545);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 41);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(134, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(841, 358);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // idTB
            // 
            this.idTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTB.Location = new System.Drawing.Point(134, 424);
            this.idTB.Name = "idTB";
            this.idTB.Size = new System.Drawing.Size(122, 28);
            this.idTB.TabIndex = 6;
            // 
            // imeTB
            // 
            this.imeTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imeTB.Location = new System.Drawing.Point(316, 424);
            this.imeTB.Name = "imeTB";
            this.imeTB.Size = new System.Drawing.Size(122, 28);
            this.imeTB.TabIndex = 7;
            // 
            // prezimeTB
            // 
            this.prezimeTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prezimeTB.Location = new System.Drawing.Point(499, 424);
            this.prezimeTB.Name = "prezimeTB";
            this.prezimeTB.Size = new System.Drawing.Size(122, 28);
            this.prezimeTB.TabIndex = 8;
            // 
            // emailTB
            // 
            this.emailTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTB.Location = new System.Drawing.Point(684, 424);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(122, 28);
            this.emailTB.TabIndex = 9;
            // 
            // passTB
            // 
            this.passTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTB.Location = new System.Drawing.Point(853, 424);
            this.passTB.Name = "passTB";
            this.passTB.Size = new System.Drawing.Size(122, 28);
            this.passTB.TabIndex = 10;
            // 
            // drzavaTB
            // 
            this.drzavaTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drzavaTB.Location = new System.Drawing.Point(684, 495);
            this.drzavaTB.Name = "drzavaTB";
            this.drzavaTB.Size = new System.Drawing.Size(122, 28);
            this.drzavaTB.TabIndex = 14;
            // 
            // gradTB
            // 
            this.gradTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradTB.Location = new System.Drawing.Point(499, 495);
            this.gradTB.Name = "gradTB";
            this.gradTB.Size = new System.Drawing.Size(122, 28);
            this.gradTB.TabIndex = 13;
            // 
            // adresaTB
            // 
            this.adresaTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adresaTB.Location = new System.Drawing.Point(316, 495);
            this.adresaTB.Name = "adresaTB";
            this.adresaTB.Size = new System.Drawing.Size(122, 28);
            this.adresaTB.TabIndex = 12;
            // 
            // telefonTB
            // 
            this.telefonTB.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonTB.Location = new System.Drawing.Point(134, 495);
            this.telefonTB.Name = "telefonTB";
            this.telefonTB.Size = new System.Drawing.Size(122, 28);
            this.telefonTB.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(495, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Surname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(680, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(849, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(130, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 23);
            this.label6.TabIndex = 21;
            this.label6.Text = "Phone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(312, 469);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(495, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 23);
            this.label8.TabIndex = 23;
            this.label8.Text = "City:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(680, 469);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "Country:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(862, 469);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 23);
            this.label10.TabIndex = 25;
            this.label10.Text = "Is Admin?";
            // 
            // adminCB
            // 
            this.adminCB.AutoSize = true;
            this.adminCB.Font = new System.Drawing.Font("Noto Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminCB.Location = new System.Drawing.Point(894, 497);
            this.adminCB.Name = "adminCB";
            this.adminCB.Size = new System.Drawing.Size(15, 14);
            this.adminCB.TabIndex = 26;
            this.adminCB.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(562, 545);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 41);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBack.Location = new System.Drawing.Point(235, 545);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 41);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 607);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.adminCB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drzavaTB);
            this.Controls.Add(this.gradTB);
            this.Controls.Add(this.adresaTB);
            this.Controls.Add(this.telefonTB);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.prezimeTB);
            this.Controls.Add(this.imeTB);
            this.Controls.Add(this.idTB);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.TextBox imeTB;
        private System.Windows.Forms.TextBox prezimeTB;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox passTB;
        private System.Windows.Forms.TextBox drzavaTB;
        private System.Windows.Forms.TextBox gradTB;
        private System.Windows.Forms.TextBox adresaTB;
        private System.Windows.Forms.TextBox telefonTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox adminCB;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBack;
    }
}