using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace CSharp.Domain
{
    public class InvoiceEntity
    {
        #region Fields & Properties
        public string InvoiceNumber { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal InvoiceTotal
        {
            get
            {
                return this.InvoiceItems.Sum(i => i.Total);
            }
        }

        public List<InvoiceItemEntity> InvoiceItems = new List<InvoiceItemEntity>();
        #endregion

        #region Constructors
        public InvoiceEntity()
        {

        }

        public InvoiceEntity(string invoiceNumber, int noOfItems, int monthOffset) : this()
        {
            InvoiceNumber = invoiceNumber;
            InvoiceItems = GenerateInvoiceItems(noOfItems);
            //InvoiceTotal = CalculateInvoiceTotal();
            InvoiceDate = GetInvoiceDate(monthOffset);
            DueDate = GetDueDate(monthOffset);
        }
        #endregion

        #region Methods
        //public decimal CalculateInvoiceTotal()
        //{
        //    decimal total = 0;
        //    foreach (var i in InvoiceItems)
        //    {
        //        total += i.Total;
        //    }
        //    return total;
        //}

        public List<InvoiceItemEntity> GenerateInvoiceItems(int noOfItems)
        {
            var list = new List<InvoiceItemEntity>();

            if (noOfItems == 0 || noOfItems > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(noOfItems));
            }

            if (noOfItems == 1)
            {
                list = new List<InvoiceItemEntity>() { new InvoiceItemEntity("Design", 600, 10, "Designing the user interface") };
            }

            if (noOfItems == 2)
            {
                list = new List<InvoiceItemEntity>() { { new InvoiceItemEntity("Development", 800, 20, "Developing the user interface") },
                                                       { new InvoiceItemEntity("Design", 600m, 6m, "Designing the marketing materials for the launch campaign") }
                };
            }

            if (noOfItems == 3)
            {
                list = new List<InvoiceItemEntity>() { { new InvoiceItemEntity("Development", 800, 12, "Developing the backend of the system") },
                                                       { new InvoiceItemEntity("Design", 600, 6, "Implementing client reverts to the front-end design") },
                                                       { new InvoiceItemEntity("Digital Marketing", 550, 12, "Developing the marketing strategy") }
                };
            }

            if (noOfItems == 4)
            {
                list = new List<InvoiceItemEntity>() { { new InvoiceItemEntity("Development", 800, 3, "Implementing bug fixes in the front-end of the application") },
                                                       { new InvoiceItemEntity("Design", 600, 6, "Re-designing the marketing material as per client reverts") },
                                                       { new InvoiceItemEntity("Digital Marketing", 550, 18, "Implementing the marketing strategy") },
                                                       { new InvoiceItemEntity("Account management", 600, 6, "Client meetings and general client admin") }

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
                output += $"  { i.ItemName } ({ i.Description }) - R{ i.Total.ToString("#,#.##", CultureInfo.InvariantCulture) }\r\n";

            }
            return $"Invoice Number: { InvoiceNumber }\r\n" +
                   $"Invoice Date: { InvoiceDate.ToString("d") }\r\n" +
                   $"Due Date: { DueDate.ToString("d") }\r\n" +
                   $"Invoice Items: { output }\r\n" +
                   $"Invoice Total: R{ InvoiceTotal.ToString("#,#.##", CultureInfo.InvariantCulture) }\r\n";
        }
        #endregion
    }
}
