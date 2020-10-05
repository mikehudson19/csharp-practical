using System;
using System.Collections.Generic;
using CSharp.Domain;

namespace CSharp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Invoice> InvoiceList = new List<Invoice>() { new Invoice("A001", 2, 0 ),
                                                              new Invoice("A002", 1, 1),
                                                              new Invoice("A003", 3, 2),
                                                              new Invoice("A004", 3, 3),
                                                              new Invoice("A003", 3, 4),
                                                              new Invoice("A003", 3, 5),
                                                              new Invoice("A003", 3, 6),
                                                              new Invoice("A003", 3, 7),
                                                              new Invoice("A003", 3, 8),
                                                              new Invoice("A003", 3, 9),
                                                              new Invoice("A003", 3, 10),
                                                              new Invoice("A003", 3, 11),
            };

            
            Console.WriteLine("App is running....press any key to exit");
            Console.ReadLine();
        }
    }
}
