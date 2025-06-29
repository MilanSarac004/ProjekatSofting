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
                    string query = "SELECT korisnik_id, is_admin FROM korisnici WHERE email=@email AND lozinka=@lozinka";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@lozinka", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int korisnikId = 0;
                        bool isAdmin = false;

                        int korisnikIdIndex = reader.GetOrdinal("korisnik_id");
                        int isAdminIndex = reader.GetOrdinal("is_admin");

                        if (!reader.IsDBNull(korisnikIdIndex))
                            korisnikId = reader.GetInt32(korisnikIdIndex);
                        else
                        {
                            MessageBox.Show("Korisnik ID je NULL u bazi. Ne može se nastaviti.");
                            return;
                        }

                        if (!reader.IsDBNull(isAdminIndex))
                            isAdmin = reader.GetBoolean(isAdminIndex);
                        else
                        {
                            MessageBox.Show("is_admin vrednost je NULL u bazi. Ne može se nastaviti.");
                            return;
                        }

                        this.Hide();

                        if (isAdmin)
                        {
                            AdminPage ap = new AdminPage();
                            ap.Show();
                        }
                        else
                        {
                            Shop shop = new Shop(korisnikId);
                            shop.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pogrešan email ili lozinka!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri logovanju: " + ex.Message);
            }
        }
    }
}
