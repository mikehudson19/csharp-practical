﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Domain;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class InvoiceItemTests
    {
        [TestMethod]
        public void CalculateItemTotalTest()
        {
            // Arrange
            var invoiceItem = new InvoiceItemEntity();
            invoiceItem.ItemRate = 500;
            invoiceItem.Hours = 15;
            var expected = 7500;

            // Act
            var actual = invoiceItem.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
