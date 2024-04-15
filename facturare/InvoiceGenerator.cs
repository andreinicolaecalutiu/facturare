using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    public delegate void InvoiceGeneratedEventHandler(object sender, EventArgs e);
    internal class InvoiceGenerator
    {
        private const string jsonFilePath = "D:\\MASTER STIA\\MEDII ȘI PLATFORME DE DEZVOLTARE AVANSATE\\facturare\\facturare\\invoice_number.json";
        public event InvoiceGeneratedEventHandler InvoiceGenerated;
        private static InvoiceGenerator? instance;
        private InvoiceGenerator() { }
        public static InvoiceGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new InvoiceGenerator();
            }
            return instance;
        }
        public void GenerateAndSaveInvoice(IInvoice invoice)
        {
            string fileName = $"{invoice.Type.Replace(" ", "_").ToLower()}_{invoice.CustomerName}.pdf";
            string path = @"D:\MASTER STIA\MEDII ȘI PLATFORME DE DEZVOLTARE AVANSATE\facturare\facturi";

            string filePath = Path.Combine(path, fileName);
            int invoiceNumber = getLastInvoiceNumber();

            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    Paragraph title = new Paragraph($"Document -- {invoice.Type} -- Numar -- {invoiceNumber}")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20)
                        .SetBold();
                    document.Add(title);

                    document.Add(new Paragraph("\n"));
                    document.Add(new LineSeparator(new SolidLine()));
                    document.Add(new Paragraph("\n"));

                    Paragraph customerInfo = new Paragraph()
                        .Add("Nume: ").Add(new Text(invoice.CustomerName).SetBold()).Add("\n")
                        .Add("Telefon: ").Add(new Text(invoice.PhoneNumber).SetBold());
                    document.Add(customerInfo);

                    document.Add(new Paragraph("\n"));
                    document.Add(new LineSeparator(new SolidLine()));
                    document.Add(new Paragraph("\n"));

                    Table table = new Table(2);
                    table.AddCell("Produs").SetTextAlignment(TextAlignment.CENTER);
                    table.AddCell("Pret").SetTextAlignment(TextAlignment.CENTER);

                    foreach (var item in invoice.Items)
                    {
                        table.AddCell(item.Description);
                        table.AddCell(item.Price.ToString());
                    }

                    table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    document.Add(table);

                    document.Add(new Paragraph("\n"));
                    document.Add(new LineSeparator(new SolidLine()));
                    document.Add(new Paragraph("\n"));

                    Paragraph subtotal = new Paragraph($"Subtotal: {invoice.Subtotal}").SetBold();
                    Paragraph total = new Paragraph($"Total (inclusiv {invoice.TaxRate}% TVA): {invoice.CalculateTotal()}").SetBold();
                    
                    document.Add(subtotal);
                    document.Add(total);

                    document.Add(new Paragraph("\n"));
                    document.Add(new LineSeparator(new SolidLine()));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));

                    Paragraph remarks = new Paragraph("Mulțummim pentru încredere!").SetTextAlignment(TextAlignment.CENTER);
                    document.Add(remarks);

                    document.Close();
                }
            }
            invoiceNumber += 1;
            updateLastInvoiceNumber(invoiceNumber);
            OnInvoiceGenerated();
        }
        protected virtual void OnInvoiceGenerated()
        {
            InvoiceGenerated?.Invoke(this, EventArgs.Empty);
        }
        public static int getLastInvoiceNumber()
        {
            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string json = File.ReadAllText(jsonFilePath);

                    var data = JsonConvert.DeserializeObject<InvoiceNumberJSON>(json);

                    return data.LastInvoiceNumber;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading JSON file: {ex.Message}");
                }
            }
            return 0;
        }
        public static void updateLastInvoiceNumber (int newNumber)
        {
            try
            {
                var data = new InvoiceNumberJSON { LastInvoiceNumber = newNumber };
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating JSON file: {ex.Message}");
            }
        }
    }
}