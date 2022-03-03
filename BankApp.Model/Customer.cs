using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Model
{
    public class Customer
    {
        /// <summary>
        /// properties and fileds for customer registration
        /// </summary>
        private static long _countAccount = 1000110000;

        private readonly int _id = 100; //auto increment field
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ContactAddress { get; set; }
        public string AccountType { get; set; }
        public long AccountNumber { get; set; }

        /// <summary>
        /// customer constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="accountType"></param>
        public Customer( string firstName, string lastName, string password, string phone, 
            string email, string accountType)
        {
            this.Id = _id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.PhoneNumber = phone;
            this.Email = email;
           
            this.AccountType = accountType;
            this.AccountNumber = _countAccount;

            ++_countAccount;
            _id++;
        }
        public Customer() { }
    }
}
