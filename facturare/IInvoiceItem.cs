using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    public interface IInvoiceItem
    {
        string Description { get; set; }
        double Price { get; set; }
    }
}
