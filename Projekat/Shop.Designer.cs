namespace Projekat
{
    partial class Shop
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
            this.flowLayoutProizvodi = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutProizvodi
            // 
            this.flowLayoutProizvodi.AutoScroll = true;
            this.flowLayoutProizvodi.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutProizvodi.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutProizvodi.Name = "flowLayoutProizvodi";
            this.flowLayoutProizvodi.Size = new System.Drawing.Size(1074, 586);
            this.flowLayoutProizvodi.TabIndex = 0;
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.Blue;
            this.btnOrder.Location = new System.Drawing.Point(914, 603);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(115, 46);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBack.Location = new System.Drawing.Point(49, 603);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 46);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Logout";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCart
            // 
            this.btnCart.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCart.Location = new System.Drawing.Point(774, 603);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(115, 46);
            this.btnCart.TabIndex = 2;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 661);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.flowLayoutProizvodi);
            this.Name = "Shop";
            this.Text = "Shop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutProizvodi;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCart;
    }
}