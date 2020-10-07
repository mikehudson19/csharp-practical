using System;

namespace CSharp.Domain
{
    public class InvoiceItem
    {

        #region Fields & Properties
        public string ItemName { get; set; }
        public double ItemRate { get; set; }
        public double Hours { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
        #endregion

        #region Constructors
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
        #endregion

        #region Methods
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
