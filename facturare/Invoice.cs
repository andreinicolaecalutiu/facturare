using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal class Invoice : IInvoice
    {
        public string Type { get; }
        public List<IInvoiceItem> Items { get; }
        public double Subtotal { get; private set; }
        public double TaxRate { get; }

        public Invoice (string type, double taxRate)
        {
            Type = type;
            TaxRate = taxRate;
            Items = new List<IInvoiceItem> ();
        }
        public void AddItem(string description, double price)
        {
            Items.Add(new InvoiceItem (description, price));
            CalculateSubtotal();
        }
        private void CalculateSubtotal()
        {
            Subtotal = 0;
            foreach (var item in Items)
            {
                Subtotal += item.Price;
            }
        }
        public double CalculateTotal()
        {
            return Subtotal * (1 + TaxRate / 100);
        }
    }
}