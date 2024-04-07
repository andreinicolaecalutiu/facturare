using facturare;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTotal_ReturnsCorrectTotal()
        {
            var invoice = new Invoice("Fiscal", 19);
            invoice.AddDetails("John Doe", "123456789");
            invoice.AddItem("Item 1", 100);
            invoice.AddItem("Item 2", 200);

            double total = invoice.CalculateTotal();

            Assert.AreEqual(357, total);
        }

        [TestMethod]
        public void AddItem_AddsItemToInvoice()
        {
            var invoice = new Invoice("Fiscal", 19);
            invoice.AddDetails("John Doe", "123456789");

            invoice.AddItem("Item 1", 100);

            Assert.AreEqual(1, invoice.Items.Count);
            Assert.AreEqual(100, invoice.Subtotal);
        }

        [TestMethod]
        public void CalculateTotal_EmptyInvoice_ReturnsZero()
        {
            var invoice = new Invoice("Fiscal", 19);

            double total = invoice.CalculateTotal();

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void Form_ClosesOnCloseMethod()
        {
            var form = new Form1();

            form.Close();

            Assert.IsTrue(form.IsDisposed);
        }
    }
}