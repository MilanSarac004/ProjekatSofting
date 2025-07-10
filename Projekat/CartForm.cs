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
    public partial class CartForm : Form
    {
        private List<CartItem> cartItems;
        public event Action<List<CartItem>> OnCartUpdated;
        public CartForm(List<CartItem> cartItems)
        {
            InitializeComponent();
            this.cartItems = cartItems;
            LoadCartItems();
        }
        private void LoadCartItems()
        {
            listViewCart.Items.Clear();

            listViewCart.View = View.Details;
            listViewCart.FullRowSelect = true;
            listViewCart.Columns.Clear();
            listViewCart.Columns.Add("Naziv", 150);
            listViewCart.Columns.Add("Kolicina", 70);
            listViewCart.Columns.Add("Cena", 70);
            listViewCart.Columns.Add("Ukupno", 80);

            foreach (var item in cartItems)
            {
                ListViewItem row = new ListViewItem(item.Naziv);
                row.SubItems.Add(item.Kolicina.ToString());
                row.SubItems.Add(item.Cena.ToString("N2"));
                row.SubItems.Add(item.Ukupno.ToString("N2"));
                row.Tag = item;

                listViewCart.Items.Add(row);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listViewCart.SelectedItems.Count > 0)
            {
                var selectedItem = listViewCart.SelectedItems[0];
                CartItem itemToRemove = (CartItem)selectedItem.Tag;
                cartItems.Remove(itemToRemove);
                LoadCartItems();

                OnCartUpdated?.Invoke(cartItems);
            }
            else
            {
                MessageBox.Show("Select Item to Remove!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
