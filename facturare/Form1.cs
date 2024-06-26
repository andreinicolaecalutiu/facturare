﻿namespace facturare
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
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            invoice.AddDetails(txtNumeClient.Text, txtPhone.Text);

            InvoiceGenerator.GetInstance().InvoiceGenerated += (sender, args) =>
            {
                MessageBox.Show("Documentul a fost emis cu succes!", "Facturare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            InvoiceGenerator.GetInstance().GenerateAndSaveInvoice(invoice);

            invoice.Items.Clear();
            txtNumeClient.Text = "";
            txtPhone.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtSubtotal.Text = "";
            txtTotal.Text = "";
        }
    }
}
