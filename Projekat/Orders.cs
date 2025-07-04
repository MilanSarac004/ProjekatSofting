using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using Org.BouncyCastle.Asn1.X509;

namespace Projekat
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private string QueryLoadDetails()
        {
            return @"
                SELECT 
                korisnici.ime + ' ' + korisnici.prezime AS ImeKorisnika,
                korisnici.email,
                korisnici.adresa,
                narudzbine.narudzbina_id,
                narudzbine.datum_narudzbine,
                SUM(stavke_narudzbine.cena_po_jedinici * stavke_narudzbine.kolicina) AS UkupnaCena,
                narudzbine.status
                FROM narudzbine
                INNER JOIN korisnici ON narudzbine.korisnik_id = korisnici.korisnik_id
                INNER JOIN stavke_narudzbine ON narudzbine.narudzbina_id = stavke_narudzbine.narudzbina_id
                WHERE narudzbine.narudzbina_id = @id
                GROUP BY korisnici.ime, korisnici.prezime, korisnici.email, korisnici.adresa, narudzbine.narudzbina_id, narudzbine.datum_narudzbine, narudzbine.status;";
        }

        private string Query()
        {
            return @"
                SELECT 
                korisnici.ime + ' ' + korisnici.prezime AS Name,
                korisnici.email AS Email,
                korisnici.adresa AS Address,
                narudzbine.narudzbina_id AS 'Order ID',
                narudzbine.datum_narudzbine AS 'Order Date',
                SUM(stavke_narudzbine.cena_po_jedinici * stavke_narudzbine.kolicina) AS 'Total Price',
                narudzbine.status AS Status
                FROM narudzbine
                INNER JOIN korisnici ON narudzbine.korisnik_id = korisnici.korisnik_id
                INNER JOIN stavke_narudzbine ON narudzbine.narudzbina_id = stavke_narudzbine.narudzbina_id
                GROUP BY korisnici.ime, korisnici.prezime, korisnici.email, korisnici.adresa, narudzbine.narudzbina_id, narudzbine.datum_narudzbine, narudzbine.status;";
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = Query();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    pnlOrderDetails.Visible = false;
                    statusCbx.Items.Add("Ocekuje se");
                    statusCbx.Items.Add("Poslato");
                    statusCbx.Items.Add("Otkazano");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminPage a = new AdminPage();
            a.Show();
            this.Hide();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Ocekuje se")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (status == "Poslato")
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (status == "Otkazano")
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = QueryLoadDetails();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", orderId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNarudzbinaValue.Text = reader["narudzbina_id"].ToString();
                        lblKupacValue.Text = reader["ImeKorisnika"].ToString();
                        lblDatumValue.Text = Convert.ToDateTime(reader["datum_narudzbine"]).ToString("dd/MM/yyyy HH:mm");
                        lblAdresaValue.Text = reader["adresa"].ToString();
                        lblCenaValue.Text = Convert.ToDecimal(reader["UkupnaCena"]).ToString("N2") + " RSD";
                        statusCbx.Text = reader["status"].ToString();

                        pnlOrderDetails.Visible = true;
                    }
                    else
                    {
                        ClearOrderDetailsPanel();
                        pnlOrderDetails.Visible = false;
                        MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearOrderDetailsPanel()
        {
            lblNarudzbinaValue.Text = "";
            lblKupacValue.Text = "";
            lblDatumValue.Text = "";
            lblAdresaValue.Text = "";
            lblCenaValue.Text = "";
            statusCbx.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            DataGridViewRow red = dataGridView1.Rows[e.RowIndex];

            if (red.Cells["Order ID"].Value == DBNull.Value || red.Cells["Order ID"].Value == null)
                return;

            int orderId = Convert.ToInt32(red.Cells["Order ID"].Value);

            LoadOrderDetails(orderId);
            LoadOrderItems(orderId);
            pnlOrderDetails.Visible = true;
        }

        private string ArchiveQuery()
        {
            return @"INSERT INTO archive SELECT 
                    narudzbine.narudzbina_id AS 'Order ID',
                    korisnici.ime + ' ' + korisnici.prezime AS Name,
                    korisnici.email AS Email,
                    korisnici.adresa AS Address,
                    narudzbine.datum_narudzbine AS 'Order Date',
                    stavke_narudzbine.cena_po_jedinici * stavke_narudzbine.kolicina AS 'Total Price',
                    narudzbine.status AS Status
                    FROM narudzbine
                    INNER JOIN korisnici ON narudzbine.korisnik_id = korisnici.korisnik_id
                    INNER JOIN stavke_narudzbine ON narudzbine.narudzbina_id = stavke_narudzbine.narudzbina_id
                    WHERE narudzbine.narudzbina_id=@id;";
        }


        private void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection conn = Database.GetConnection())
                {
                    int rowIndex = 0;
                    if (dataGridView1.CurrentCell != null)
                    {
                        rowIndex = dataGridView1.CurrentCell.RowIndex;
                    }

                    DataGridViewRow red = dataGridView1.Rows[rowIndex];
                    if(red.Cells["Status"].Value.ToString() == "Ocekuje se")
                    {
                        MessageBox.Show("You can't archive order that is not completed or cancelled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(red.Cells["Status"].Value.ToString() == "Poslato" || red.Cells["Status"].Value.ToString() == "Otkazano")
                    {
                        conn.Open();
                        string sql = ArchiveQuery();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblNarudzbinaValue.Text));
                        MessageBox.Show("Order Archived!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        cmd.ExecuteNonQuery();

                        DataTable dt = (DataTable)dataGridView1.DataSource;
                        foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            dt.Rows.RemoveAt(row.Index);
                        }

                        string sqlRemove = @"DELETE FROM narudzbine WHERE narudzbina_id = @idRemove;";
                        SqlCommand cmd2 = new SqlCommand(sqlRemove, conn);
                        cmd2.Parameters.AddWithValue("@idRemove", Convert.ToInt32(lblNarudzbinaValue.Text));
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlOrderDetails.Visible = false;
            dataGridView1.ClearSelection();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Update Status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE narudzbine SET status=@status WHERE narudzbina_id=@id;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", statusCbx.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblNarudzbinaValue.Text));
                    cmd.ExecuteNonQuery();
                    Orders_Load(sender, e);
                    MessageBox.Show("Status Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems(int orderId)
        {
            try
            {
                if (!int.TryParse(lblNarudzbinaValue.Text, out orderId))
                {
                    MessageBox.Show("Order ID not vaild.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                SELECT proizvodi.proizvod_id,proizvodi.naziv,kolicina 
                FROM stavke_narudzbine INNER JOIN proizvodi ON stavke_narudzbine.proizvod_id=proizvodi.proizvod_id 
                WHERE stavke_narudzbine.narudzbina_id=@id;";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
            catch(Exception ex)  
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenArch_Click(object sender, EventArgs e)
        {
            Archive a = new Archive();
            a.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select order for generating PDF.", "No selected order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString() == "Otkazano")
            {
                MessageBox.Show("You cannot generate PDF for cancelled orders.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows[0].Cells["Order ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Order ID not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int orderIdToGeneratePdf = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Order ID"].Value);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = $"Order_{orderIdToGeneratePdf}.pdf";
                sfd.Title = "Save PDF";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GeneratePdf(sfd.FileName, orderIdToGeneratePdf);
                        MessageBox.Show("PDF successfully created and saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while generating PDF: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GeneratePdf(string filePath, int orderId)
        {
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font fontSmall = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);

                string customerName = "";
                string shippingAddress = "";
                DateTime orderDate = DateTime.MinValue;
                decimal totalAmount = 0m;
                string orderStatus = "";

                DataTable orderItemsTable = new DataTable();

                try
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();

                        string sql = QueryLoadDetails();
                        using (SqlCommand cmdOrder = new SqlCommand(sql, conn))
                        {
                            cmdOrder.Parameters.AddWithValue("@id", orderId);
                            using (SqlDataReader reader = cmdOrder.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    orderDate = reader.GetDateTime(reader.GetOrdinal("datum_narudzbine"));
                                    totalAmount = reader.GetDecimal(reader.GetOrdinal("UkupnaCena"));
                                    orderStatus = reader.GetString(reader.GetOrdinal("status"));
                                    customerName = reader.GetString(reader.GetOrdinal("ImeKorisnika"));
                                    shippingAddress = reader.GetString(reader.GetOrdinal("adresa"));
                                }
                                else
                                {
                                    throw new Exception("Order not found.");
                                }
                            }
                        }

                        string itemsQuery = "SELECT proizvodi.proizvod_id,proizvodi.naziv,kolicina, cena_po_jedinici FROM stavke_narudzbine INNER JOIN proizvodi ON stavke_narudzbine.proizvod_id = proizvodi.proizvod_id WHERE stavke_narudzbine.narudzbina_id = @id";
                        using (SqlCommand cmdItems = new SqlCommand(itemsQuery, conn))
                        {
                            cmdItems.Parameters.AddWithValue("@id", orderId);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmdItems))
                            {
                                da.Fill(orderItemsTable);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database error: " + ex.Message, ex);
                }

                document.Add(new Paragraph("Muzički Instrumenti DOO", fontHeader));
                document.Add(new Paragraph("Adresa firme: Glavna 123, 24000 Subotica", fontNormal));
                document.Add(new Paragraph("Telefon: 024/123-456", fontNormal));
                document.Add(new Paragraph("Email: info@muzinstr.rs", fontNormal));
                document.Add(new Paragraph("\n"));

                Paragraph title = new Paragraph("RAČUN", fontTitle);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n\n"));

                document.Add(new Paragraph($"Broj narudžbine: {orderId}", fontNormal));
                document.Add(new Paragraph($"Datum narudžbine: {orderDate.ToString("dd.MM.yyyy HH:mm")}", fontNormal));
                document.Add(new Paragraph($"Status: {orderStatus}", fontNormal));
                document.Add(new Paragraph("\n"));

                document.Add(new Paragraph("Kupac:", fontTitle));
                document.Add(new Paragraph($"Ime: {customerName}", fontNormal));
                document.Add(new Paragraph($"Adresa isporuke: {shippingAddress}", fontNormal));
                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 3f, 1f, 1.5f, 1.5f });

                table.AddCell(new PdfPCell(new Phrase("Instrument", fontNormal)) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Količina", fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Cena/jed.", fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Ukupno", fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY });

                foreach (DataRow row in orderItemsTable.Rows)
                {
                    string productName = row["naziv"].ToString();
                    int quantity = Convert.ToInt32(row["kolicina"]);
                    decimal pricePerUnit = Convert.ToDecimal(row["cena_po_jedinici"]);
                    decimal totalItemPrice = quantity * pricePerUnit;

                    table.AddCell(new PdfPCell(new Phrase(productName, fontNormal)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(quantity.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(pricePerUnit.ToString("N2"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(totalItemPrice.ToString("N2"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }

                document.Add(table);
                document.Add(new Paragraph("\n"));

                Paragraph totalParagraph = new Paragraph($"UKUPNO ZA NAPLATU: {totalAmount.ToString("N2")} RSD", fontTitle);
                totalParagraph.Alignment = Element.ALIGN_RIGHT;
                document.Add(totalParagraph);
                document.Add(new Paragraph("\n\n"));

                Paragraph thankYou = new Paragraph("Hvala na kupovini!", fontNormal);
                thankYou.Alignment = Element.ALIGN_CENTER;
                document.Add(thankYou);

                Paragraph footer = new Paragraph($"Datum generisanja: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}", fontSmall);
                footer.Alignment = Element.ALIGN_RIGHT;
                document.Add(footer);

                document.Close();
            }
        }
    }
}
