using System;

namespace CSharp.Domain
{
    public class Invoice
    {
        public DateTimeOffset InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public double InvoiceTotal { get; set; }

        public Invoice()
        {
            this.InvoiceDate = DateTimeOffset.Now;
            this.DueDate = DateTimeOffset.Now;
            this.InvoiceTotal = 500;
        }

        public Invoice(string invoiceNumber) : this()
        {
            this.InvoiceNumber = invoiceNumber;

        }
    }
}
