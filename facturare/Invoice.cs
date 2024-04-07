using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    public class Invoice : IInvoice
    {
        public int InvoiceNumber { get; set; }
        public string Type { get; }
        public List<IInvoiceItem> Items { get; }
        public double Subtotal { get; private set; }
        public double TaxRate { get; }
        public String CustomerName {  get; private set; }
        public String PhoneNumber {  get; private set; }

        public Invoice (string type, double taxRate)
        {
            Type = type;
            TaxRate = taxRate;
            Items = new List<IInvoiceItem> ();
        }
        public void AddDetails(String name, String phone)
        {
            CustomerName = name;
            PhoneNumber = phone;
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
            double total = Subtotal * (1 + TaxRate / 100);
            return Math.Round(total, 2);
        }
    }
}