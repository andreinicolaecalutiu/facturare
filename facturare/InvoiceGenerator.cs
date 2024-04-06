using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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

            string fileName = $"{invoice.Type.Replace(" ", "_").ToLower()}_invoice.pdf";
            string path = @"C:\Users\andre\OneDrive\Desktop";

            string filePath = Path.Combine(path, fileName);

            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    document.Add(new Paragraph($"Type: {invoice.Type}"));

                    foreach (var item in invoice.Items)
                    {
                        document.Add(new Paragraph($"Item: {item.Description}, Price: {item.Price}"));
                    }

                    document.Add(new Paragraph($"Subtotal: {invoice.Subtotal}"));
                    document.Add(new Paragraph($"Total (including {invoice.TaxRate}% VAT): {invoice.CalculateTotal()}"));
                    document.Close();
                }
            }
            MessageBox.Show(invoice.Subtotal.ToString() + invoice.TaxRate.ToString() + invoice.CalculateTotal().ToString());
            MessageBox.Show($"Factura de tipul {invoice.Type} a fost generată și salvată ca {fileName}");
        }
    }
}
