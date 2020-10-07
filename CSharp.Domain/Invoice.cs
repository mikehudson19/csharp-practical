using System;
using System.Collections.Generic;
using System.Globalization;


namespace CSharp.Domain
{
    public class Invoice
    {
        #region Fields & Properties
        internal string InvoiceNumber { get; set; }
        internal DateTimeOffset InvoiceDate { get; set; }
        internal DateTimeOffset DueDate { get; set; }
        internal double InvoiceTotal { get; set; }
        public List<InvoiceItem> InvoiceItems = new List<InvoiceItem>();
        #endregion

        #region Constructors
        public Invoice()
        {
           
        }

        public Invoice(string invoiceNumber, int noOfItems, int monthOffset) : this()
        {
            InvoiceNumber = invoiceNumber;   
            InvoiceItems = GenerateInvoiceItems(noOfItems);        
            InvoiceTotal = CalculateInvoiceTotal(); 
            InvoiceDate = GetInvoiceDate(monthOffset);
            DueDate = GetDueDate(monthOffset); 
        }
        #endregion

        #region Methods
        public double CalculateInvoiceTotal()
        {
            double total = 0;
            foreach (var i in InvoiceItems)
            {
               total += i.Total;
            }
            return total;
        }

        public List<InvoiceItem> GenerateInvoiceItems(int noOfItems)
        {
            var list = new List<InvoiceItem>();

            if (noOfItems == 1)
            {
                list = new List<InvoiceItem>() { new InvoiceItem("Development", 800, 5, "Software development") };  
            }

            if (noOfItems == 2)
            {
                list = new List<InvoiceItem>() { { new InvoiceItem("Development", 800, 5, "Software development") },
                                                 { new InvoiceItem("Design", 600, 6, "Software design") }
                };
            }

            if (noOfItems == 3)
            {
                list = new List<InvoiceItem>() { { new InvoiceItem("Development", 800, 5, "Software development") },
                                                 { new InvoiceItem("Design", 600, 6, "Software design") },
                                                 { new InvoiceItem("Digital Marketing", 550, 12, "Devising the marketing strategy") }
                };
            }

            return list;
        }

        public DateTimeOffset GetInvoiceDate(int monthOffset)
        {
            var month = DateTime.UtcNow.AddMonths(monthOffset).Month;

            int year;

            // Determine whether the invoice date is in a new year, or not.
            if ((12 - DateTime.UtcNow.Month) >= monthOffset)
            {
               year = DateTime.UtcNow.Year;
            }
            else
            {
               year = DateTime.UtcNow.AddYears(1).Year;
            }

            var day = DateTime.DaysInMonth(year, month) - 5;

            var myDate = new DateTime(year, month, day, 0, 0, 0);
            return myDate;

        }

        public DateTimeOffset GetDueDate(int monthOffset)
        {
            var monthDue = GetInvoiceDate(monthOffset + 1);
            var month = monthDue.Month;
            var year = monthDue.Year;
            var day = DateTime.DaysInMonth(year, month);

            return new DateTime(year, month, day, 0, 0, 0);

        }

        public override string ToString()
        {
            string output = "\r\n";
            foreach (var i in InvoiceItems)
            {
                output += $"  { i.ItemName } ({ i.Description }) - R{ i.Total.ToString("#,#", CultureInfo.InvariantCulture) }\r\n";
                
            }
            return $"Invoice Number: { InvoiceNumber }\r\n" +
                   $"Invoice Date: { InvoiceDate.ToString("d") }\r\n" +
                   $"Due Date: { DueDate.ToString("d") }\r\n" +
                   $"Invoice Items: { output }\r\n" +
                   $"Invoice Total: R{ InvoiceTotal.ToString("#,#", CultureInfo.InvariantCulture) }\r\n";
        }
        #endregion
    }
}
