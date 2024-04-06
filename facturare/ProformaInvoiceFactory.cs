using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal class ProformaInvoiceFactory : IInvoiceFactory
    {
        public IInvoice CreateInvoice(string type, double taxRate)
        {
            return new Invoice(type, taxRate);
        }
    }
}
