using System.Collections.Generic;

namespace BOL
{
    public class Payment
    {
        public string intent;
        public Payer payer;
        public List<Transaction> transactions;
        public RedirectUrls redirect_urls;
    }
}
