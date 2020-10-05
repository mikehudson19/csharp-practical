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
        public int NoOfItems;
        public int DateVar;

        public Invoice()
        {
           
        }

        public Invoice(string invoiceNumber, int noOfItems, int dateVar) : this()
        {
            InvoiceNumber = invoiceNumber;
            GenerateItems(noOfItems);
            InvoiceTotal = CalculateTotal();
            InvoiceDate = GetDate(dateVar);
            DueDate = GetDueDate(dateVar); 
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var i in InvoiceItems)
            {
               total += i.Total;
            }
            return total;
        }

        public void GenerateItems(int noOfItems)
        {
            if (noOfItems == 1)
            {
                InvoiceItems.Add(new InvoiceItem("Development", 5, 800, "Software development"));
            }

            if (noOfItems == 2)
            {
                InvoiceItems.Add(new InvoiceItem("Development", 5, 800, "Software development"));
                InvoiceItems.Add(new InvoiceItem("Design", 5, 600, "Software design"));
            }

            if (noOfItems == 3)
            {
                InvoiceItems.Add(new InvoiceItem("Development", 5, 800, "Software development"));
                InvoiceItems.Add(new InvoiceItem("Design", 5, 600, "Software design"));
                InvoiceItems.Add(new InvoiceItem("Digital Marketing", 5, 750, "Pushing products"));
            }
        }

        public DateTime GetDate(int dateVar)
        {
            var month = DateTime.UtcNow.AddMonths(dateVar).Month;

            int year;

            if ((12 - DateTime.UtcNow.Month) >= dateVar)
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

        public DateTime GetDueDate(int invoiceDate)
        {
            var invoicedDate = GetDate(invoiceDate +1);
            var nextMonth = invoicedDate.Month;
            var year = invoicedDate.Year;
            var day = DateTime.DaysInMonth(year, nextMonth);
            return new DateTime(year, nextMonth, day, 0, 0, 0);

        }
    }
}
