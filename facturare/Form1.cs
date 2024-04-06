namespace facturare
{
    public partial class Form1 : Form
    {
        private IInvoice invoice;
        private IInvoiceFactory invoiceFactory;
        public Form1()
        {
            InitializeComponent();
            invoiceFactory = new TaxInvoiceFactory();
            invoice = invoiceFactory.CreateInvoice("Factura", 19);
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            invoice.AddItem(description, price);

            txtSubtotal.Text = invoice.Subtotal.ToString();
            txtTotal.Text = invoice.CalculateTotal().ToString();

            txtDescription.Text = "";
            txtPrice.Text = "";

            //MessageBox.Show(description + price);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            double taxRate = Convert.ToDouble(txtTaxRate.Text);
            invoice = invoiceFactory.CreateInvoice("Factura", taxRate);
            InvoiceGenerator.GetInstance().GenerateAndSaveInvoice(invoice, txtNumeClient.Text);

            txtDescription.Text = "";
            txtPrice.Text = "";
            txtSubtotal.Text = "";
            txtTotal.Text = "";
        }
    }
}
