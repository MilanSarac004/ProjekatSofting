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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Text.RegularExpressions;

namespace Projekat
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool ValidateData(out string errorMessage)
        {
            errorMessage = "";

            string password = passwordTxt.Text.Trim();
            string confirm = confirmPassTxt.Text.Trim();
            string email = emailTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(nameTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(surnameTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(emailTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(phoneTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(countryTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(cityTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(addressTxt.Text.Trim()) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                errorMessage = "Please fill in all fields.";
                return false;
            }

            if (password != confirm)
            {
                errorMessage = "Passwords do not match.";
                return false;
            }

            if (password.Length < 6)
            {
                errorMessage = "Password must be at least 6 characters.";
                return false;
            }

            if (!IsValidEmail(email))
            {
                errorMessage = "Enter valid email address.";
                return false;
            }

            return true;
        }

        private int getID()
        {
            string query = "SELECT MAX(korisnik_id) FROM korisnici";

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                return Convert.ToInt32(cmd.ExecuteScalar() ?? 0)+1;
            }
        }

        private void ClearInputs()
        {
            nameTxt.Clear();
            surnameTxt.Clear();
            emailTxt.Clear();
            addressTxt.Clear();
            passwordTxt.Clear();
            confirmPassTxt.Clear();
            cityTxt.Clear();
            countryTxt.Clear();
            phoneTxt.Clear();
        }


        private void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string message;
                if (!ValidateData(out message))
                {
                    MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = @"INSERT INTO korisnici(korisnik_id, ime, prezime, email, lozinka, telefon, adresa, grad, drzava, is_admin) VALUES (@id, @name, @surname, @email, @password, @phone, @address, @city, @country, 0)";
                        int id = getID();
                        SqlCommand sql = new SqlCommand(query, conn);
                        sql.Parameters.AddWithValue("@id", id);
                        sql.Parameters.AddWithValue("@name", nameTxt.Text);
                        sql.Parameters.AddWithValue("@surname", surnameTxt.Text);
                        sql.Parameters.AddWithValue("@email", emailTxt.Text);
                        sql.Parameters.AddWithValue("@password", passwordTxt.Text);
                        if (!int.TryParse(phoneTxt.Text, out int phone) || phoneTxt.TextLength != 10)
                        {
                            MessageBox.Show("Invalid phone number!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                        sql.Parameters.AddWithValue("@phone", phone);
                        sql.Parameters.AddWithValue("@address", addressTxt.Text);
                        sql.Parameters.AddWithValue("@city", cityTxt.Text);
                        sql.Parameters.AddWithValue("@country", countryTxt.Text);

                        sql.ExecuteNonQuery();
                        ClearInputs();

                        MessageBox.Show("User account created!","Register successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
