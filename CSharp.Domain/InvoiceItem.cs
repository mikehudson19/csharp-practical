using System;

namespace CSharp.Domain
{
    public class InvoiceItem
    {

        #region Fields & Properties
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        #endregion

        #region Constructors
        public InvoiceItem()
        {
        }

        public InvoiceItem(string itemName, decimal itemRate, decimal hours, string description) : this()
        {
            ItemName = itemName;
            ItemRate = itemRate;
            Hours = hours;
            Description = description;
            Total = CalculateItemTotal();

        }
        #endregion

        #region Methods
        public decimal CalculateItemTotal()
        {
            return ItemRate * Hours;
        }

        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
