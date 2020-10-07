using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Domain;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class InvoiceTests
    {

        [TestMethod]
        public void CalculateInvoiceTotalTest()
        {
            // Arrange
            var invoice = new Invoice();
            invoice.InvoiceItems = new List<InvoiceItem>()
            {
                { new InvoiceItem("Development", 800, 10, "Software development") },
                { new InvoiceItem("Design", 600, 10, "Software design") },
                { new InvoiceItem("Digital Marketing", 400, 10, "Devising the marketing strategy") }
            };
            var expected = 18000;

            // Act
            var actual = invoice.CalculateInvoiceTotal();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateInvoiceItemsTest()
        {
            // Arrange
            var invoice = new Invoice();
            var expected = new List<InvoiceItem>()
            { { new InvoiceItem("Development", 800, 12, "Developing the backend of the system") },
              { new InvoiceItem("Design", 600, 6, "Implementing client reverts to the front-end design") },
              { new InvoiceItem("Digital Marketing", 550, 12, "Developing the marketing strategy") }
            };

            // Act
            var actual = invoice.GenerateInvoiceItems(3);

            // Assert
            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected[i].ItemName, actual[i].ItemName);
                Assert.AreEqual(expected[i].ItemRate, actual[i].ItemRate);
                Assert.AreEqual(expected[i].Hours, actual[i].Hours);
                Assert.AreEqual(expected[i].Description, actual[i].Description);
                Assert.AreEqual(expected[i].Total, actual[i].Total);
            }
        }

        [TestMethod]
        public void GetInvoiceDate_NewYearTest()
        {
            // Arrange
            var invoice = new Invoice();
            var month = DateTime.UtcNow.Month;
            var year = DateTime.UtcNow.Year;
            var day = DateTime.DaysInMonth(year, month) - 5;
            var expected = new DateTime(year, month, day, 0, 0, 0);

            // Act
            var actual = invoice.GetInvoiceDate(0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetInvoiceDate_SameYearTest()
        {
            // Arrange
            var invoice = new Invoice();
            var month = DateTime.UtcNow.Month;
            var year = DateTime.UtcNow.AddYears(1).Year;
            var day = DateTime.DaysInMonth(year, month) - 5;
            var expected = new DateTime(year, month, day, 0, 0, 0);

            // Act
            var actual = invoice.GetInvoiceDate(12);

            // Assert
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod]
        public void GetDueDateTest()
        {
            // Arrange
            var invoice = new Invoice();
            var expected = new DateTime(2020, 11, 30, 0, 0, 0);

            // Act
            var actual = invoice.GetDueDate(0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
