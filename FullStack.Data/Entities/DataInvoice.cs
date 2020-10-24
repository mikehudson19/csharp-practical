using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Data.Entities
{
    public class DataInvoice
    {

        public DataInvoice()
        {
            InvoiceItems = new List<DataInvoiceItem>();
        }
    
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public List<DataInvoiceItem> InvoiceItems { get; set; }

    }
}
