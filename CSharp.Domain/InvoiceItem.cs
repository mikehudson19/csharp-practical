using System;

namespace CSharp.Domain
{
    public class InvoiceItem
    {
        internal string ItemName { get; set; }
        internal double ItemRate { get; set; }
        internal double Hours { get; set; }
        internal string Description { get; set; }
        internal double Total { get; set; }



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

        public override string ToString()
        {
            return Description;
        }
    }
}
