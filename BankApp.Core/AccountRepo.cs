using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BankApp.Common;
using BankApp.Data;
using BankApp.Model;

namespace BankApp.Core
{
    public class AccountRepo
    {
        //private Customer customer;
        //private Account account;
        private TransactionRepo transaction = new TransactionRepo();
         
        
        DateTime date = DateTime.Now;

        public long _accountNumber = 1100110011;
        

        private int id = 1;

        /// <summary>
        /// Creates account for customer
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="initialDeposit"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public Account CreateAccount(string accountName, long initialDeposit, string accountType)
        {
            
            Account account = new Account(id, _accountNumber, accountName, initialDeposit, accountType);
            Store.accounts.Add(account);
            _accountNumber++;
            id++;
            return account;

        }
        

        /// <summary>
        /// to get customer account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public double GetAccountBalanceByAccountNumber(long accountNumber)
        {
            foreach (var account in Store.accounts)
            {
                if (account.AccountNumber.Equals(accountNumber))
                {
                    return account.Balance;
                }
            }
            return 0.0;
        }


        /// <summary>
        /// to get customer account details
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public bool GetAccountDetails(long accountNumber)
        {
            Account findAccount = Store.accounts.FirstOrDefault(accnt => accnt.AccountNumber == accountNumber);

            string details = "";

            if (findAccount != null)
            {
                Console.WriteLine("=======================================================================");
                Console.WriteLine("Account Name | Account No. | Account Type | Balance    | Date Created |");
                Console.WriteLine("=======================================================================");
                Console.WriteLine(
                    $"| {findAccount.AccountName.ToString()}   | {findAccount.AccountNumber.ToString()}  | {findAccount.AccountType.ToString()}      |" +
                    $" {findAccount.Balance.ToString()}   | {findAccount.DateOfCreation.ToShortDateString()} |");
                Console.WriteLine("=======================================================================");
                return true;
            }
            else
                throw new ArgumentNullException("There's an error in the transaction, Please try again");

            return false;
        }



        /// <summary>
        /// prints customer info
        /// </summary>
        public void Print()
        {
            DisplayInfo.PrintLines();
            DisplayInfo.PrintHeadings("ACCOUNT NAME","ACCOUNT NUMBER", "ACCOUNT TYPE", "BALANCE");
            DisplayInfo.PrintLines();
            foreach (var  item in Store.accounts )
            {
                DisplayInfo.PrintHeadings(item.AccountName, item.AccountNumber.ToString(), item.AccountType, item.Balance.ToString());
                DisplayInfo.PrintLines();
            }
        }  
    }
}
