namespace Projekat
{
    partial class CartForm
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
            this.listViewCart = new System.Windows.Forms.ListView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewCart
            // 
            this.listViewCart.HideSelection = false;
            this.listViewCart.Location = new System.Drawing.Point(12, 12);
            this.listViewCart.Name = "listViewCart";
            this.listViewCart.Size = new System.Drawing.Size(1032, 552);
            this.listViewCart.TabIndex = 0;
            this.listViewCart.UseCompatibleStateImageBehavior = false;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(320, 583);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 53);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(589, 583);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(121, 53);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 648);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.listViewCart);
            this.Name = "CartForm";
            this.Text = "CartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRemove;
    }
}