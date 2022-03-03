using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BankApp.Model
{
    public class Transaction
    {
        private int count = 1100;
        public int Id;
        public double Amount { get; }
        public  string Fullname { get; set; }
        public string AccountType { get; set; }
        public long AccountNumber { get; set; }

        public string TansactionDate;
        public string Description { get; }
        public string TransactionType { get; set; }


        /// <summary>
        /// Constructor for the transaction class
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="accountNumber"></param>
        /// <param name="accountType"></param>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        public Transaction(string fullName, long accountNumber, 
            string accountType, double amount, string description, string transactionType)
        {
            this.Fullname = fullName;
            this.Id = count;
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.Amount = amount;
            this.TansactionDate = DateTime.Now.ToShortDateString();
            this.Description = description;
            this.TransactionType = transactionType;
            count++;
        }
    }
}
