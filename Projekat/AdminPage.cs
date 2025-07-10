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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders o = new Orders();
            o.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
