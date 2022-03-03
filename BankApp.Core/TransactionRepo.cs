using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankApp.Common;
using BankApp.Data;
using BankApp.Model;

namespace BankApp.Core
{
    public class TransactionRepo
    {
        private Transaction transactions;



        /// <summary>
        /// method that handles customer deposit transactions
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool Deposit(long accountNumber, double amount, string description)
        {
            Account findAccount = Store.accounts.FirstOrDefault(item => item.AccountNumber == accountNumber);
            if (findAccount != null)
            {
                findAccount.Balance += amount;

                Transaction transaction = new Transaction(findAccount.AccountName, accountNumber,
                    findAccount.AccountType, amount, description, "credit");
                Store.transactions.Add(transaction);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return true;
        }



        /// <summary>
        /// handles customer withdrawal transaction
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool Withdraw(long accountNumber, double amount, string description)
        {
            //authenticate account number
            Account findAccount = Store.accounts.FirstOrDefault(i => i.AccountNumber == accountNumber);
            if (findAccount != null)
            {
                if (findAccount.AccountType == "Savings" && findAccount.Balance - amount < 1000)
                    return false;
                if (findAccount.AccountType == "Current" && findAccount.Balance - amount < 0)
                    return false;

                findAccount.Balance -= amount;

                Transaction transaction = new Transaction(findAccount.AccountName, accountNumber,
                    findAccount.AccountType, amount, description, "debit");
                Store.transactions.Add(transaction);
            }
            else
                throw new ArgumentNullException();
            
            return true;
        }
        

        /// <summary>
        /// method that transfer fund from one account to another
        /// </summary>
        /// <param name="senderAccountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="receiverAccountNumber"></param>
        /// <param name="description"></param>
        /// <returns></returns>
       public bool TransferFund(long senderAccountNumber, int amount, long receiverAccountNumber, string description)
       {

           //authenticate sender's account number
            Account findAccount = Store.accounts.FirstOrDefault(item => item.AccountNumber == senderAccountNumber);
           if (findAccount != null)
           {
               if (findAccount.AccountType == "1" && findAccount.Balance - amount < 1000)
                {
                    return false;
                }
                   
               else if (findAccount.AccountType == "2" && findAccount.Balance - amount < 0)
                   return false;

                //authenticate receiver's account number
                Account findReceiverAccount = Store.accounts.FirstOrDefault(item => item.AccountNumber == receiverAccountNumber);
                if (findReceiverAccount != null)
                {
                    findAccount.Balance -= amount; //debit sender
                    Transaction transaction = new Transaction(findAccount.AccountName, senderAccountNumber,
                        findAccount.AccountType, amount, description, "debit");
                    Store.transactions.Add(transaction);

                    
                    findReceiverAccount.Balance += amount; //credit receiver
                    Transaction anotherTransaction = new Transaction(findAccount.AccountName, receiverAccountNumber,
                        findAccount.AccountType, amount, description, "credit");
                    Store.transactions.Add(anotherTransaction);

                }
                else
                    throw new ArgumentNullException();
           }
           else
               throw new ArgumentNullException();

            return true;
       }

    }
}
