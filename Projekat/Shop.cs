using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Projekat
{
    public partial class Shop : Form
    {
        private List<CartItem> cartItems = new List<CartItem>();
        private int korisnikId;
        private string korisnikIme = "";
        private string korisnikPrezime = "";
        private string korisnikAdresa = "";
        private string korisnikTelefon = "";


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
                    string slikaPutanja = string.IsNullOrEmpty(slikaRelativno)
                        ? ""
                        : Path.Combine(Application.StartupPath, slikaRelativno.Replace('/', Path.DirectorySeparatorChar));
                    item.SlikaPath = slikaPutanja;

                    item.OnAddToCart += (s, cartItem) =>
                    {
                        cartItems.Add(cartItem);
                        MessageBox.Show($"{cartItem.Naziv} added to cart.", "Add To Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    flowLayoutProizvodi.Controls.Add(item);
                }
            }
        }

        private void LoadKorisnikInfo()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT ime, prezime, adresa, telefon FROM korisnici WHERE korisnik_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", korisnikId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        korisnikIme = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        korisnikPrezime = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        korisnikAdresa = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        korisnikTelefon = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    }
                }
            }
        }

        private int GetNextNarudzbinaId()
        {
            string query = "SELECT ISNULL(MAX(narudzbina_id), 0) + 1 FROM narudzbine";

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        private int GetNextStavkaId()
        {
            string query = "SELECT ISNULL(MAX(stavka_id), 0) + 1 FROM stavke_narudzbine";

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is Empty!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal ukupnaCena = 0;
            foreach (var item in cartItems)
                ukupnaCena += item.Ukupno;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                int narudzbinaId = GetNextNarudzbinaId();
                string narudzbinaQuery = "INSERT INTO narudzbine (narudzbina_id, korisnik_id, datum_narudzbine, ukupna_cena, status) " +
                                         "VALUES (@id, @korisnik_id, @datum, @ukupna, 'U obradi')";

                SqlCommand cmd = new SqlCommand(narudzbinaQuery, conn);
                cmd.Parameters.AddWithValue("@id", narudzbinaId);
                cmd.Parameters.AddWithValue("@korisnik_id", korisnikId);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                cmd.Parameters.AddWithValue("@ukupna", ukupnaCena);
                cmd.ExecuteNonQuery();

                foreach (var item in cartItems)
                {
                    int stavkaId = GetNextStavkaId();
                    string stavkaQuery = "INSERT INTO stavke_narudzbine (stavka_id, narudzbina_id, proizvod_id, kolicina, cena_po_jedinici) " +
                                         "VALUES (@stavka_id, @narudzbina_id, @proizvod_id, @kolicina, @cena)";

                    SqlCommand stavkaCmd = new SqlCommand(stavkaQuery, conn);
                    stavkaCmd.Parameters.AddWithValue("@stavka_id", stavkaId);
                    stavkaCmd.Parameters.AddWithValue("@narudzbina_id", narudzbinaId);
                    stavkaCmd.Parameters.AddWithValue("@proizvod_id", item.ProizvodId);
                    stavkaCmd.Parameters.AddWithValue("@kolicina", item.Kolicina);
                    stavkaCmd.Parameters.AddWithValue("@cena", item.Cena);
                    stavkaCmd.ExecuteNonQuery();
                }
            }

            LoadKorisnikInfo();
            GeneratePDFReceipt(cartItems, ukupnaCena);
            MessageBox.Show("Order Successfull! Bill generated.", "Thank You!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cartItems.Clear();
        }

        private void GeneratePDFReceipt(List<CartItem> items, decimal total)
        {
            string filePath = Path.Combine(Application.StartupPath, "Racun.pdf");

            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font fontSmall = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);

                document.Add(new Paragraph("Muzicki Instrumenti DOO", fontHeader));
                document.Add(new Paragraph("Adresa firme: Glavna 123, 24000 Subotica", fontNormal));
                document.Add(new Paragraph("Telefon: 024/123-456", fontNormal));
                document.Add(new Paragraph("Email: info@muzinstr.rs", fontNormal));
                document.Add(new Paragraph("\n"));

                Paragraph title = new Paragraph("RACUN", fontTitle);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n\n"));

                document.Add(new Paragraph($"Kupac: {korisnikIme} {korisnikPrezime}", fontNormal));
                document.Add(new Paragraph($"Adresa: {korisnikAdresa}", fontNormal));
                document.Add(new Paragraph($"Telefon: {korisnikTelefon}", fontNormal));
                document.Add(new Paragraph("\n"));

                document.Add(new Paragraph($"Datum izdavanja: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}", fontNormal));
                document.Add(new Paragraph("Status: U obradi", fontNormal));
                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 3f, 1f, 1.5f, 1.5f });

                table.AddCell(new PdfPCell(new Phrase("Instrument", fontNormal)) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Kolicina", fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Cena/jed.", fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Ukupno", fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY });

                foreach (var item in items)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.Naziv, fontNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.Kolicina.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(item.Cena.ToString("N2"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(item.Ukupno.ToString("N2"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }

                document.Add(table);
                document.Add(new Paragraph("\n"));

                Paragraph totalParagraph = new Paragraph($"UKUPNO ZA NAPLATU: {total.ToString("N2")} RSD", fontTitle);
                totalParagraph.Alignment = Element.ALIGN_RIGHT;
                document.Add(totalParagraph);
                document.Add(new Paragraph("\n\n"));

                Paragraph thankYou = new Paragraph("Hvala na kupovini!", fontNormal);
                thankYou.Alignment = Element.ALIGN_CENTER;
                document.Add(thankYou);

                Paragraph footer = new Paragraph($"Datum generisanja: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}", fontSmall);
                footer.Alignment = Element.ALIGN_RIGHT;
                document.Add(footer);

                var qrContent = new System.Text.StringBuilder();
                qrContent.AppendLine("Racun stavke:");
                foreach (var item in items)
                {
                    qrContent.AppendLine($"{item.Naziv} x{item.Kolicina} - {item.Cena.ToString("N2")} RSD = {item.Ukupno.ToString("N2")} RSD");
                }
                qrContent.AppendLine($"UKUPNO: {total.ToString("N2")} RSD");

                var qrCode = new BarcodeQRCode(qrContent.ToString(), 150, 150, null);
                var qrImage = qrCode.GetImage();
                qrImage.Alignment = Element.ALIGN_CENTER;
                document.Add(qrImage);

                document.Close();
            }

            Process.Start("explorer.exe", filePath);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm cf = new CartForm(cartItems);
            cf.OnCartUpdated += (updatedCart) =>
            {
                cartItems = updatedCart;
            };
            cf.ShowDialog();
        }
    }
}
