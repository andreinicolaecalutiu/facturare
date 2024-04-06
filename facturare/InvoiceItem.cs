using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal class InvoiceItem : IInvoiceItem
    {
        public string Description { get; set; }
        public double Price { get; set; }

        public InvoiceItem(string description, double price) { 
            Description = description;
            Price = price;
        }
    }
}
