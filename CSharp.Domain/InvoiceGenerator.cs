using System;
using System.Collections.Generic;

namespace CSharp.Domain
{
    public static class InvoiceGenerator
    {

        public static List<InvoiceEntity> GenerateInvoices()
        {

            return new List<InvoiceEntity>() { new InvoiceEntity("INV0001", 1, 0),
                                               new InvoiceEntity("INV0002", 3, 1),
                                               new InvoiceEntity("INV0003", 2, 2),
                                               new InvoiceEntity("INV0004", 2, 3),
                                               new InvoiceEntity("INV0005", 3, 4),
                                               new InvoiceEntity("INV0006", 4, 5),
                                               new InvoiceEntity("INV0007", 3, 6),
                                               new InvoiceEntity("INV0008", 4, 7),
                                               new InvoiceEntity("INV0009", 2, 8),
                                               new InvoiceEntity("INV0010", 1, 9),
                                               new InvoiceEntity("INV0011", 4, 10),
                                               new InvoiceEntity("INV0012", 2, 11)
            };

        }

        public static InvoiceEntity GenerateInvoice(string invNo, int invoiceItems, int monthOffset)
        {
            return new InvoiceEntity(invNo, invoiceItems, monthOffset);
        }
    }
}
    