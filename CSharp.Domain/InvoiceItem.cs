using System;

namespace CSharp.Domain
{
    public class InvoiceItem
    {
        public string ItemName { get; set; }
        public double ItemRate { get; set; }
        public double Hours { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }



        public InvoiceItem()
        {
        }

        public InvoiceItem(string itemName, double itemRate, double hours, string description) : this()
        {
            ItemName = itemName;
            ItemRate = itemRate;
            Hours = hours;
            Description = description;
            Total = Hours * ItemRate;

        }
    }
}
