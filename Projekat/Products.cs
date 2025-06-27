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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void LoadProizvodi()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.proizvod_id, p.naziv, p.opis, p.cena, p.dostupna_kolicina, k.naziv AS kategorije FROM proizvodi p INNER JOIN kategorije k ON p.kategorija_id = k.kategorija_id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtProizvodID.Text = row.Cells["proizvod_id"].Value.ToString();
            txtNaziv.Text = row.Cells["naziv"].Value.ToString();
            txtOpis.Text = row.Cells["opis"].Value.ToString();
            txtCena.Text = row.Cells["cena"].Value.ToString();
            txtKolicina.Text = row.Cells["dostupna_kolicina"].Value.ToString();
            txtKategorija.Text = row.Cells["kategorije"].Value.ToString();

            txtProizvodID.Enabled = false;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadProizvodi();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try { 
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO proizvodi (proizvod_id, naziv, opis, cena, dostupna_kolicina, kategorija_id) VALUES (@id, @naziv, @opis, @cena, @kolicina, (SELECT kategorija_id FROM kategorije WHERE naziv=@kategorije))";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtProizvodID.Text));
                cmd.Parameters.AddWithValue("@naziv", txtNaziv.Text);
                cmd.Parameters.AddWithValue("@opis", txtOpis.Text);
                cmd.Parameters.AddWithValue("@cena", decimal.Parse(txtCena.Text));
                cmd.Parameters.AddWithValue("@kolicina", int.Parse(txtKolicina.Text));
                cmd.Parameters.AddWithValue("@kategorije", txtKategorija.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProizvodi();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try { 
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE proizvodi SET naziv=@naziv, opis=@opis, cena=@cena, dostupna_kolicina=@kolicina, kategorija_id=(SELECT kategorija_id FROM kategorije WHERE naziv=@kategorije)WHERE proizvod_id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@naziv", txtNaziv.Text);
                cmd.Parameters.AddWithValue("@opis", txtOpis.Text);
                cmd.Parameters.AddWithValue("@cena", decimal.Parse(txtCena.Text));
                cmd.Parameters.AddWithValue("@kolicina", int.Parse(txtKolicina.Text));
                cmd.Parameters.AddWithValue("@kategorije", txtKategorija.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtProizvodID.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProizvodi();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Delete Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM proizvodi WHERE proizvod_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtProizvodID.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProizvodi();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtProizvodID.Clear();
            txtNaziv.Clear();
            txtOpis.Clear();
            txtCena.Clear();
            txtKolicina.Clear();
            txtKategorija.Clear();
            txtProizvodID.Enabled = true;
        }
    }
}
