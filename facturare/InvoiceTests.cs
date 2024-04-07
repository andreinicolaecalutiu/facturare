using NUnit.Framework;

namespace facturare
{
    [TestFixture]
    public class InvoiceTests
    {
        [Test]
        public void CalculateTotal_ReturnsCorrectTotal()
        {
            var invoice = new Invoice("Fiscal", 19);
            invoice.AddDetails("John Doe", "123456789");
            invoice.AddItem("Item 1", 100);
            invoice.AddItem("Item 2", 200);

            double total = invoice.CalculateTotal();

            Assert.Equals(330, total);
        }

        [Test]
        public void AddItem_AddsItemToInvoice()
        {
            var invoice = new Invoice("Fiscal", 19);
            invoice.AddDetails("John Doe", "123456789");

            invoice.AddItem("Item 1", 100);

            Assert.Equals(1, invoice.Items.Count); 
            Assert.Equals(100, invoice.Subtotal);
        }

        [Test]
        public void CalculateTotal_EmptyInvoice_ReturnsZero()
        {
            var invoice = new Invoice("Fiscal", 19);

            double total = invoice.CalculateTotal();

            Assert.Equals(0, total);
        }

        [Test]
        public void Form_ClosesOnCloseMethod()
        {
            var form = new Form1();

            form.Close();

            Assert.That(form.IsDisposed);
        }
    }
}
