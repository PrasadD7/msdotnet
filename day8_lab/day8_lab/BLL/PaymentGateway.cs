using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
namespace BLL
{
    public class PaymentGateway
    {

       Payment payment;
        public  Payment CreatePayment( string redirectUrl)
        {

            //create itemlist and add item objects to it
            var itemList = new ItemList() { items = new List<Item>() };

            //Adding Item Details like name, currency, price etc
            itemList.items.Add(new Item()
            {
                name = "Item Name comes here",
                currency = "USD",
                price = "1",
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { paymentMethod = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancelUrl = redirectUrl + "&Cancel=true",
                returnUrl = redirectUrl
            };

            // Adding Tax, shipping and Subtotal details
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };

            //Final amount with details
            var amount = new Amount()
            {
                Currency = "USD",
                Total = "3", // Total must be equal to sum of tax, shipping and subtotal.
                Details = "More Information"
            };

            var transactionList = new List<Transaction>();
            // Adding description about the transaction
            transactionList.Add(new Transaction()
            {
                Description = "Transaction description",
                InvoiceNumber = "your generated invoice number", //Generate an Invoice No
                TransactionAmount = amount,
                Items  = itemList
            });

            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext
            return this.payment;
        }
        public  Payment ExecutePayment( string payerId, string paymentId)
        {
            
            this.payment = new Payment() {  };
            return this.payment;
        }
        public void ApprovePayment() { }
        public void CancelPayment() { }


    }
}
