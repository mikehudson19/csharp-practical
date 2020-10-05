using System;
using System.Collections.Generic;

namespace CSharp.Domain
{
    public class Invoice
    {
        public DateTimeOffset InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public double InvoiceTotal { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public List<InvoiceItem> InvoiceItems = new List<InvoiceItem>();

        public Invoice()
        {
            this.InvoiceDate = DateTimeOffset.Now;
            this.DueDate = DateTimeOffset.Now;
            GenerateItems();
        }

        public Invoice(string invoiceNumber, double num1, double num2) : this()
        {
            this.InvoiceNumber = invoiceNumber;
            this.Num1 = num1;
            this.Num2 = num2;
            this.InvoiceTotal = CalculateTotal();
        }

        public double CalculateTotal()
        {
            return Num1 * Num2;
            // Loop through the Dictionary of items
            // Access the item total               
            // Add each total to the InvoiceTotal  
        }

        public void GenerateItems()
        {
            InvoiceItems.Add(new InvoiceItem("Development", 5, 800, "Software development" ));
            InvoiceItems.Add(new InvoiceItem("Design", 5, 600, "Software design" ));
            InvoiceItems.Add(new InvoiceItem("Digital Marketing", 5, 750, "Pushing products"));

        }
    }
}
