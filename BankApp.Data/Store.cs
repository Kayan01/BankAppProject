using System;
using System.Collections.Generic;
using BankApp.Model;

namespace BankApp.Data
{
    /// <summary>
    /// holds all customer data
    /// </summary>
    public static class Store
    {
        public static List<Account> accounts = new List<Account>();

        public static List<Customer> customers = new List<Customer>();

        public static List<Transaction> transactions = new List<Transaction>();
    }
}
