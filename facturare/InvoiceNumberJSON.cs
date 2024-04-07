using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturare
{
    internal class InvoiceNumberJSON
    {
        [JsonProperty("last_invoice_number")]
        public int LastInvoiceNumber { get; set; }
    }
}
