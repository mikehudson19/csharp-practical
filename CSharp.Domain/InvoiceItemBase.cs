using System;
namespace CSharp.Domain
{
    public class InvoiceItemBase
    {

        #region Fields & Properties
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        #endregion

    
    }
}
