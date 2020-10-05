using System;
using System.Collections.Generic;
using CSharp.Domain;

namespace CSharp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Invoice> InvoiceList = new List<Invoice>() { new Invoice("A001"), new Invoice("A002"), new Invoice("A003") };
            Console.WriteLine(InvoiceList[1].InvoiceNumber);

            Console.WriteLine("App is running....press any key to exit");
            Console.ReadLine();
        }
    }
}
