using System;
using System.Collections.Generic;
using FullStack.Data.Entities;

namespace FullStack.ViewModels
{
    public class InvoiceDTO
    {
        
        public string InvoiceNumber { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public List<InvoiceItemDTO> InvoiceItems { get; set; }
    }
}
