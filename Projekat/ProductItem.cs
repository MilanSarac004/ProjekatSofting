using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class ProductItem : UserControl
    {
        public int ProizvodId { get; set; }
        public string Naziv
        {
            get => lblNaziv.Text;
            set => lblNaziv.Text = value;
        }
        public string Opis
        {
            get => lblOpis.Text;
            set => lblOpis.Text = value;
        }
        public decimal Cena
        {
            get => decimal.Parse(lblCena.Text.Replace(" RSD", ""));
            set => lblCena.Text = value + " RSD";
        }

        public string SlikaPath
        {
            get => pictureBox1.ImageLocation;
            set => pictureBox1.ImageLocation = value;
        }

        public event EventHandler<CartItem> OnAddToCart;

        public ProductItem()
        {
            InitializeComponent();
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            OnAddToCart?.Invoke(this, new CartItem
            {
                ProizvodId = this.ProizvodId,
                Naziv = this.Naziv,
                Cena = this.Cena,
                Kolicina = 1
            });
        }
    }
}
