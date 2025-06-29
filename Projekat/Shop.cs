using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Projekat
{
    public partial class Shop : Form
    {
        private List<CartItem> cartItems = new List<CartItem>();
        private int korisnikId;
        public Shop(int korisnikId)
        {
            InitializeComponent();
            if (korisnikId <= 0)
                throw new ArgumentException("Invalid User ID!");

            this.korisnikId = korisnikId;
            LoadProizvodi();
        }
        private void LoadProizvodi()
        {
            flowLayoutProizvodi.Controls.Clear();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT proizvod_id, naziv, opis, cena, slika FROM proizvodi";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new ProductItem();

                    item.ProizvodId = reader.GetInt32(0);
                    item.Naziv = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    item.Opis = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    item.Cena = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);

                    string slikaRelativno = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    string slikaPutanja = string.IsNullOrEmpty(slikaRelativno) ? "" : Path.Combine(Application.StartupPath, slikaRelativno.Replace('/', Path.DirectorySeparatorChar));
                    item.SlikaPath = slikaPutanja;

                    item.OnAddToCart += (s, cartItem) =>
                    {
                        cartItems.Add(cartItem);
                        MessageBox.Show($"{cartItem.Naziv} dodat u korpu.");
                    };

                    flowLayoutProizvodi.Controls.Add(item);
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Korpa je prazna.");
                return;
            }

            decimal ukupnaCena = 0;
            foreach (var item in cartItems)
            {
                ukupnaCena += item.Ukupno;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string narudzbinaQuery = "INSERT INTO narudzbine (korisnik_id, datum_narudzbine, ukupna_cena, status) OUTPUT INSERTED.narudzbina_id VALUES (@korisnik_id, @datum, @ukupna, 'U obradi')";
                SqlCommand cmd = new SqlCommand(narudzbinaQuery, conn);
                cmd.Parameters.AddWithValue("@korisnik_id", korisnikId);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                cmd.Parameters.AddWithValue("@ukupna", ukupnaCena);
                int narudzbinaId = (int)cmd.ExecuteScalar();

                foreach (var item in cartItems)
                {
                    string stavkaQuery = "INSERT INTO stavke_narudzbine (narudzbina_id, proizvod_id, kolicina, cena_po_jedinici) VALUES (@narudzbina_id, @proizvod_id, @kolicina, @cena)";
                    SqlCommand stavkaCmd = new SqlCommand(stavkaQuery, conn);
                    stavkaCmd.Parameters.AddWithValue("@narudzbina_id", narudzbinaId);
                    stavkaCmd.Parameters.AddWithValue("@proizvod_id", item.ProizvodId);
                    stavkaCmd.Parameters.AddWithValue("@kolicina", item.Kolicina);
                    stavkaCmd.Parameters.AddWithValue("@cena", item.Cena);
                    stavkaCmd.ExecuteNonQuery();
                }
            }

            GeneratePDFReceipt(cartItems, ukupnaCena);
            MessageBox.Show("Narudžbina uspešna! Račun generisan.");
            cartItems.Clear();
        }
        private void GeneratePDFReceipt(List<CartItem> items, decimal total)
        {
            string filePath = Path.Combine(Application.StartupPath, "Racun.pdf");

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph("Račun"));
            doc.Add(new Paragraph("Datum: " + DateTime.Now.ToString()));
            doc.Add(new Paragraph("-------------------------"));

            foreach (var item in items)
            {
                doc.Add(new Paragraph($"{item.Naziv} x{item.Kolicina} - {item.Cena} RSD = {item.Ukupno} RSD"));
            }

            doc.Add(new Paragraph("-------------------------"));
            doc.Add(new Paragraph("Ukupno: " + total + " RSD"));

            var qrCode = new BarcodeQRCode("Ukupno: " + total + " RSD", 150, 150, null);
            var img = qrCode.GetImage();
            doc.Add(img);

            doc.Close();

            Process.Start("explorer", filePath);
        }
    }
}
