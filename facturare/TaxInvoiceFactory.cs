using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal class TaxInvoiceFactory : IInvoiceFactory
    {
        public IInvoice CreateInvoice(string type, double TaxRate)
        {
            return new Invoice(type, TaxRate);
        }
    }
}
