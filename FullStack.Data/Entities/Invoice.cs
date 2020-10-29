using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Data.Entities
{
    public class Invoice
    {

        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
    
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }

    }
}
