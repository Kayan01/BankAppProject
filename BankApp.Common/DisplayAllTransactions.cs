using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Data;

namespace BankApp.Common
{
    public static class DisplayAllTransactions
    {
        /// <summary>
        /// Prints statement of all transactions
        /// </summary>
        public static void PrintAllTransactions()
        {
            List<double> accountBalances = new List<double>();
            for (int i = 0; i < Store.transactions.Count; i++)
            {
                if (Store.transactions[i].TransactionType == "credit")
                {
                    if (accountBalances.Count < 1)
                    {
                        accountBalances.Add(Store.transactions[i].Amount);
                    }
                    else
                    {
                        accountBalances.Add(accountBalances[i - 1] + Store.transactions[i].Amount);
                    }
                }
                else
                {
                    accountBalances.Add(accountBalances[i - 1] - Store.transactions[i].Amount);
                }
            }

            DisplayInfo.PrintLines();
            DisplayInfo.PrintHeadings("DATE", "DESCRIPTION", "AMOUNT", "TYPE", "BALANCE");
            DisplayInfo.PrintLines();
            foreach (var item in Store.transactions)
            {
                DisplayInfo.PrintHeadings(item.TansactionDate.ToString(), item.Description, item.Amount.ToString(), item.TransactionType, accountBalances[Store.transactions.IndexOf(item)].ToString());
                DisplayInfo.PrintLines();
            }
        }
    }
}
