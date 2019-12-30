using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Transaction
    {
        public string Description { get; set; }
        public string InvoiceNumber { get; set; }
        public  Amount TransactionAmount { get; set; }
        public ItemList Items { get; set; }
    }
}
