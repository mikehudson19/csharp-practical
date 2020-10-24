using System;
namespace FullStack.Data.Entities
{
    public class DataInvoiceItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public DataInvoice DataInvoice { get; set; }
        public int DataInvoiceId { get; set; }
    }
}
