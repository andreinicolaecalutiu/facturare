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
        string CustomerName { get; }
        string PhoneNumber { get; }
        void AddDetails(string customerName, string phoneNumber);
        void AddItem(string description, double Price);
        double CalculateTotal();
    }
}