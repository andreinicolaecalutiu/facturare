using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal interface IInvoiceFactory
    {
        IInvoice CreateInvoice(string type, double taxRate);
    }
}
