using System;
namespace FullStack.ViewModels
{
    public class InvoiceItemDTO
    {
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }

    }
}
