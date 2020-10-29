using System;

namespace CSharp.Domain
{
    public class InvoiceItemEntity
    {

        #region Fields & Properties
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
        public decimal Total
        {
            get
            {
                var result = Math.Round(this.Hours * this.ItemRate, 2);
                return result;
            }

        }
        #endregion

        #region Constructors
        public InvoiceItemEntity()
        {
        }

        public InvoiceItemEntity(string itemName, decimal itemRate, decimal hours, string description) : this()
        {
            ItemName = itemName;
            ItemRate = itemRate;
            Hours = hours;
            Description = description;

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
