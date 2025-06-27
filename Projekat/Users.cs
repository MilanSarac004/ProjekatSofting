using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Xml.Linq;

namespace Projekat
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM korisnici";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Delete User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM korisnici WHERE korisnik_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(idTB.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE korisnici SET korisnik_id=@id, ime=@name, prezime=@surname, email=@email, lozinka=@pass, telefon=@phone, adresa=@address, grad=@city, drzava=@country, is_admin=@admin WHERE korisnik_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(idTB.Text));
                    cmd.Parameters.AddWithValue("@name", imeTB.Text);
                    cmd.Parameters.AddWithValue("@surname", prezimeTB.Text);
                    cmd.Parameters.AddWithValue("@email", emailTB.Text);
                    cmd.Parameters.AddWithValue("@pass", passTB.Text);
                    cmd.Parameters.AddWithValue("@phone", int.Parse(telefonTB.Text));
                    cmd.Parameters.AddWithValue("@address", adresaTB.Text);
                    cmd.Parameters.AddWithValue("@city", gradTB.Text);
                    cmd.Parameters.AddWithValue("@country", drzavaTB.Text);
                    cmd.Parameters.AddWithValue("@admin", Boolean.Parse(adminCB.Checked.ToString()));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTB.Enabled = false;

            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            DataGridViewRow red = dataGridView1.Rows[e.RowIndex];

            idTB.Text = red.Cells["korisnik_id"].Value.ToString();
            imeTB.Text = red.Cells["ime"].Value.ToString();
            prezimeTB.Text = red.Cells["prezime"].Value.ToString();
            emailTB.Text = red.Cells["email"].Value.ToString();
            passTB.Text = red.Cells["lozinka"].Value.ToString();
            telefonTB.Text = red.Cells["telefon"].Value.ToString();
            adresaTB.Text = red.Cells["adresa"].Value.ToString();
            gradTB.Text = red.Cells["grad"].Value.ToString();
            drzavaTB.Text = red.Cells["drzava"].Value.ToString();
            adminCB.Checked = Convert.ToBoolean(red.Cells["is_admin"].Value);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            idTB.Clear();
            imeTB.Clear();
            prezimeTB.Clear();
            emailTB.Clear();
            passTB.Clear();
            telefonTB.Clear();
            adresaTB.Clear();
            drzavaTB.Clear();
            adminCB.Checked = false;
            gradTB.Clear();
            idTB.Enabled = true;
            dataGridView1.ClearSelection();
        }
    }
}
