using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = emailTxt.Text.Trim();
                string password = passTxt.Text.Trim();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT is_admin FROM korisnici WHERE email=@email AND lozinka=@lozinka";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@lozinka", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bool isAdmin = reader.GetBoolean(0);
                        this.Hide();

                        if (isAdmin)
                        {
                            AdminPage ap = new AdminPage();
                            ap.Show();
                        }
                        else
                        {
                            Shop shop = new Shop();
                            shop.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong email or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Hide();
        }
    }
}
