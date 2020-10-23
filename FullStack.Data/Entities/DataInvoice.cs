using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Data.Entities
{
    public class DataInvoice
    {
    
        [Key]
        public string InvoiceNumber { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        //public List<InvoiceItem> InvoiceItems = new List<InvoiceItem>();
      
    }
}
