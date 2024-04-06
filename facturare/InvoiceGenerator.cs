using iText.Kernel.Font;
using iText.Kernel.Pdf;
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
            string path = @"C:\Users\andre\OneDrive\Desktop";

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

                    Paragraph customerInfo = new Paragraph()
                        .Add("Name: ").Add(new Text(invoice.CustomerName).SetBold()).Add("\n")
                        .Add("Phone: ").Add(new Text(invoice.PhoneNumber).SetBold());
                    document.Add(customerInfo);

                    Table table = new Table(2).SetTextAlignment(TextAlignment.CENTER);
                    table.AddCell("Description").SetBold();
                    table.AddCell("Price").SetBold();

                    foreach (var item in invoice.Items)
                    {
                        table.AddCell(item.Description);
                        table.AddCell(item.Price.ToString());
                    }

                    document.Add(table);

                    Paragraph subtotal = new Paragraph($"Subtotal: {invoice.Subtotal}").SetBold();
                    Paragraph total = new Paragraph($"Total (including {invoice.TaxRate}% VAT): {invoice.CalculateTotal()}").SetBold();
                    
                    document.Add(subtotal);
                    document.Add(total);

                    Paragraph remarks = new Paragraph("Thank you for doing business with us! No need for stamp or signature!").SetTextAlignment(TextAlignment.CENTER);
                    document.Add(remarks);

                    document.Close();
                }
            }
            MessageBox.Show($"Factura de tipul {invoice.Type} a fost generată și salvată ca {fileName}");
        }
    }
}
