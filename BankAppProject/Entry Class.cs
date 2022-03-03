using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using BankApp.Common;
using BankApp.Model;
using BankApp.Core;
using BankApp.Data;

namespace BankAppProject.UI
{
    class EntryClass
    {
        private CustomerRepo customerRepo = new CustomerRepo();
        private Customer customer = new Customer();
        private AccountRepo accountRepo = new AccountRepo();
        //AccountRepo myAccount = new AccountRepo();
        private TransactionRepo transaction = new TransactionRepo();
        public void Start()
        {

            string password = String.Empty;
            string pass = String.Empty;
            while (true)
            {
                Console.WriteLine($"Kindly press \n1:Login for existing Customer \n2: For new customer to create an account\n3: To exit");

                string option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter your registered email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter password!");
                        pass = Console.ReadLine();
                        Console.WriteLine("This Email does not exist.\nPlease go back and create account");
                        Console.WriteLine(customerRepo.Login(email, password) ? "Login Successful!" : "Invalid credentials");
                        AccountInfo();
                        break;

                    case "2":
                        Console.WriteLine("Enter a username ");
                        email = Console.ReadLine();

                        Console.WriteLine("Enter password\n(PassWord must be 6 - 15 letters long\nbe alphanumeric\nmust contain special characters e.g @#%");
                    checkPassword:
                        password = Console.ReadLine();
                        if (!Validation.ValidatePassword(password))
                        {
                            Console.WriteLine("Wrong password format");
                            goto checkPassword;
                        }

                    checkFirstName:
                        Console.WriteLine("Enter your first name\n(Start with a capital letter)");
                        string firstName = Console.ReadLine();
                        if (!Validation.ValidateName(firstName))
                            goto checkFirstName;

                        checkLastName:
                        Console.WriteLine("Enter your LastName");
                        string lastName = Console.ReadLine();
                        if (!Validation.ValidateName(lastName))
                            goto checkLastName;

                        checkPhoneNumber:
                        Console.WriteLine("enter phone number");
                        string phoneNumber = Console.ReadLine();
                        if (!Validation.ValidatePhoneNumber(phoneNumber))
                        {
                            Console.WriteLine("Phone Number must be 11 digits");
                            goto checkPhoneNumber;
                        }

                    checkEmail:
                        Console.WriteLine("Enter valid email");
                        string emailAdd = Console.ReadLine();
                        if (!Validation.ValidateEmail(emailAdd))
                        {
                            Console.WriteLine("email should be in this format abcde@efgddw.com");
                            goto checkEmail;
                        }

                    checkAccountType:
                        Console.WriteLine("Choose account type (Press 1 for savings or 2 for  current)");
                        string accType = Console.ReadLine();// "current";
                        if (accType == "2")
                            accType = AccountType.accountType.Current.ToString();
                        else if (accType == "2")
                        {
                            accType = AccountType.accountType.Savings.ToString();
                            /*  else
                              {
                                  Console.WriteLine("please enter the word properly");
                              } */
                            goto checkAccountType;
                        }


                    checkAmount:
                        Console.WriteLine("Enter amount to fund your account!");
                        int amount;
                        bool amountStatus = Int32.TryParse(Console.ReadLine(), out amount);
                        if (!amountStatus)
                            goto checkAmount;
                        if (amount < 1000 && accType == "Savings")
                        {
                            Console.WriteLine("Minimum of #1000 required for savings account!");
                            goto checkAmount;
                        }


                        customerRepo.Register(password, firstName, lastName, phoneNumber, email, accType);

                        accountRepo.CreateAccount(firstName + " " + lastName, amount, accType);
                        long sendAccountNumber = accountRepo._accountNumber - 1;
                        Console.WriteLine("Your AccountNumber is :" + sendAccountNumber.ToString());
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();



                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again!");
                        break;
                }
            }
        }

        void AccountInfo()
        {
        AccountInterface:
            Console.Clear();
            InputMessage();

            string start = Console.ReadLine();

            if (start == "1")
            {
            checkAccount1:
                Console.Write("Enter Account Number: ");
                long accountNumber = Convert.ToInt64(Console.ReadLine());

                Account find = Store.accounts.FirstOrDefault(item => item.AccountNumber == accountNumber);
                if (find != null)
                {
                    Console.Write("Enter  Amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Description: ");
                    string description = Console.ReadLine();

                    try
                    {
                        transaction.Deposit(accountNumber, amount, description);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error detected: " + e);
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account!");
                    goto checkAccount1;
                }


                goto AccountInterface;
            }

            if (start == "2")
            {
            ConfirmAcc:
                Console.Write("Enter your account number:  ");
                long accountNum = Convert.ToInt64(Console.ReadLine());

                Account findAccount = Store.accounts.FirstOrDefault(i => i.AccountNumber == accountNum);
                if (findAccount != null)
                {
                    Console.Write("Enter amount to withdraw:  ");
                    double amountToWithdraw = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Enter transaction description:  ");
                    string description = Console.ReadLine();
                    try
                    {
                        transaction.Withdraw(accountNum, amountToWithdraw, description); //performs withrawal
                        Console.WriteLine("Successful!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error detected: " + e);
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account!");
                    goto ConfirmAcc;
                }


                goto AccountInterface;
            }

            if (start == "3")
            {
                Console.WriteLine("Enter receiver's account number");
                var receiver = Convert.ToInt64(Console.ReadLine());
                Account findAccount = Store.accounts.FirstOrDefault(i => i.AccountNumber == receiver);
                if (findAccount == null)
                {
                    Console.WriteLine("Account does not exist");
                    goto AccountInterface;
                }
                else
                {
                    Console.WriteLine("Enter amount");
                    var amt = Convert.ToInt64(Console.ReadLine());
                }

                try
                {
                    transaction.TransferFund(1100110011, 1500, 1100110012, "Fee");
                    Console.WriteLine("Success!\nPress any key to continue!");
                    Console.ReadKey();

                    goto AccountInterface;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error detected: " + e);
                    throw;
                }

            }

            


            

                if (start == "4")
                {
                    accountRepo.Print();
                    Console.WriteLine("\nSuccess! \nPress any key to continue!");
                    Console.ReadKey();

                    goto AccountInterface;
                }

                if (start == "5")
                {
                    DisplayAllTransactions.PrintAllTransactions();
                    Console.WriteLine("\nSuccess!\nPress any key to continue!");
                    Console.ReadKey();

                    goto AccountInterface;
                }



                if (start == "6")
                {
                    Console.Write("Enter account number: ");
                    long accountNm = Convert.ToInt64(Console.ReadLine());
                    //string balance = "";

                    try
                    {
                        accountRepo.GetAccountDetails(accountNm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid account number" + e);
                        throw;
                    }

                    Console.WriteLine("\nSuccess!\nPress any key to continue!");
                    Console.ReadKey();

                    goto AccountInterface;
                }

                if (start == "7")
                {
                    //customerRepo.Logout();

                    goto AccountInterface;
                }
                if (start == "")
                {
                    Environment.Exit(0);
                }

                if (start != "1" && start != "2" && start != "3" && start != "4" && start != "5" && start != "6" && start != "7" && start != "8" && start != "")
                {
                    Console.WriteLine("Invalid key, try again.");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();

                    goto AccountInterface;
                }
            }

            void InputMessage()
            {
                string name = string.Empty;
                foreach (Customer user in Store.customers)
                {
                    var customer = user;
                    name = user.FirstName;
                }
                Console.WriteLine("====================================================================");
                Console.WriteLine(@"       Welcome to Kayan International Bank {0}",name);
                Console.WriteLine(@"        Your One-Stop Bank.");
                Console.WriteLine("===============================================\n");
                Console.WriteLine("         Account Transaction Interface");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Enter 1 to deposit");
                Console.WriteLine("Enter 2 to withdraw");
                Console.WriteLine("Enter 3 to transfer");
                Console.WriteLine("Enter 4 to print account details");
                Console.WriteLine("Enter 5 to print statement of account");
                Console.WriteLine("Enter 6 to get your account balance");
                Console.WriteLine("Enter 7 to logout");
                Console.WriteLine("Enter 8 to Exit");
            }
        }
    }
