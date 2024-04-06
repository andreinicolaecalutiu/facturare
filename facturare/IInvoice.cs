using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal interface IInvoice
    {
        string Type { get; }
        List<IInvoiceItem> Items { get; }
        double Subtotal { get; }
        double TaxRate { get; }
        void AddItem(string description, double Price);
        double CalculateTotal();
    }
}