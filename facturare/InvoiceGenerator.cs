using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal class InvoiceGenerator
    {
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

            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    Paragraph title = new Paragraph($"Document -- {invoice.Type}")
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
            MessageBox.Show($"Documentul de tipul {invoice.Type} a fost generată și salvată ca {fileName}");
        }
    }
}