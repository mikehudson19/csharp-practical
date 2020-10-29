using System;
namespace FullStack.Data.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
        public int InvoiceId { get; set; }
    }
}
