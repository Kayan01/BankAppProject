using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using BankApp.Common;
using BankApp.Data;
using BankApp.Model;

namespace BankApp.Core
{
    public class CustomerRepo
    {
        public Customer _customer;

        /// <summary>
        /// user login method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string email, string password)
        {
            foreach (var customer in Store.customers)
            {
                if (customer.Email.Equals(email) && customer.Password.Equals(password))
                {
                    return true;
                }
            }

            return false;
        }
            

        /// <summary>
        /// logs out customer
        /// </summary>
        /// <returns></returns>
        public bool Logout() {
            Environment.Exit(0);
            return true;
        }

        /// <summary>
        /// customer registration method
        /// </summary>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
      /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="accType"></param>
        /// <returns></returns>
        public Customer Register(string email, string password, string firstName, string lastName,
            string phoneNumber,  string accType)
        {

            string accountType = "";
            if (accType == "Current")
                accountType = AccountType.accountType.Current.ToString();
            else
                accountType = AccountType.accountType.Savings.ToString();


            _customer = new Customer(firstName, lastName, password,
                phoneNumber, email, accountType);


            Store.customers.Add(_customer);
            Console.WriteLine("success!");

            return _customer;
        }
    }
}
