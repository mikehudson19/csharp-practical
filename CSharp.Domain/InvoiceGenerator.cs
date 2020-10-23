using System;
using System.Collections.Generic;

namespace CSharp.Domain
{
    public static class InvoiceGenerator
    {

        public static List<Invoice> GenerateInvoices()
        {

            return new List<Invoice>() { new Invoice("INV0001", 1, 0),
                                         new Invoice("INV0002", 3, 1),
                                         new Invoice("INV0003", 2, 2),
                                         new Invoice("INV0004", 2, 3),
                                         new Invoice("INV0005", 3, 4),
                                         new Invoice("INV0006", 4, 5),
                                         new Invoice("INV0007", 3, 6),
                                         new Invoice("INV0008", 4, 7),
                                         new Invoice("INV0009", 2, 8),
                                         new Invoice("INV0010", 1, 9),
                                         new Invoice("INV0011", 4, 10),
                                         new Invoice("INV0012", 2, 11)
            };

        }

        public static Invoice GenerateInvoice()
        {
            return new Invoice("INV0015", 3, 0);
        }
    }
}
