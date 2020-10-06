using System;
using System.Collections.Generic;

namespace CSharp.Domain
{
    public static class InvoiceGenerator
    {

        public static List<Invoice> GenerateInvoices()
        {

            return new List<Invoice>() { new Invoice("A001", 2, 0),
                                         new Invoice("A002", 1, 1),
                                         new Invoice("A003", 3, 2),
                                         new Invoice("A004", 3, 3),
                                         new Invoice("A005", 3, 4),
                                         new Invoice("A005", 3, 5),
                                         new Invoice("A006", 3, 6),
                                         new Invoice("A007", 3, 7),
                                         new Invoice("A008", 3, 8),
                                         new Invoice("A009", 3, 9),
                                         new Invoice("A010", 3, 10),
                                         new Invoice("A011", 3, 11)
            };

        }
    }
}
