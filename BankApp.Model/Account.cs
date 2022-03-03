using System;

namespace BankApp.Model
{
    public class Account
    {
        
        /// <summary>
        /// properties for accounts opening
        /// </summary>
        public long AccountNumber { get; set; }
        public int Id { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; }
        public DateTime DateOfCreation { get; set; }


        /// <summary>
        /// account constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountNumber"></param>
        /// <param name="accountName"></param>
        /// <param name="initialDeposit"></param>
        /// <param name="accountType"></param>
        public Account(int id, long accountNumber,string accountName, long initialDeposit, string accountType)
        {
            this.Id = id;
            this.AccountNumber = accountNumber;
            this.Balance = initialDeposit;
            this.AccountType = accountType;
            this.AccountName = accountName;
            this.DateOfCreation = DateTime.Now;
            
        }

        public double GetBalance() => Balance;
    }
}
