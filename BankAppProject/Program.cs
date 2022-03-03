using System;
using BankAppProject.UI;

namespace BankAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            EntryClass entryClass = new EntryClass();

            Console.WriteLine(@"       You are welcome to Kayan's International Bank");
            Console.WriteLine(@"        We value your partnership...");
            Console.WriteLine("===============================================\n");




            entryClass.Start();


        }
    }
}
