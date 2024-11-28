using System;
using System.Collections.Generic;

class Program
{
    // Class to represent a Bank Account
    class BankAccount
    {
        public string AccountHolder { get; set; }
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        // Constructor
        public BankAccount(string accountHolder, int accountNumber)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = 0; // Initialize balance to zero
        }

        // Method to deposit money
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid amount. Deposit failed.");
            }
        }

        // Method to withdraw money
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient balance. Withdrawal failed.");
            }
        }

        // Method to check balance
        public void ShowBalance()
        {
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Current Balance: {Balance:C}");
        }
    }

    static void Main()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        int nextAccountNumber = 1001; // Start account numbers from 1001

        while (true)
        {
            Console.WriteLine("\nWelcome to the Banking System!");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Create Account
                    Console.Write("Enter account holder's name: ");
                    string name = Console.ReadLine();
                    var newAccount = new BankAccount(name, nextAccountNumber++);
                    accounts[newAccount.AccountNumber] = newAccount;
                    Console.WriteLine($"Account created successfully! Account Number: {newAccount.AccountNumber}");
                    break;

                case "2": // Deposit
                    Console.Write("Enter account number: ");
                    if (int.TryParse(Console.ReadLine(), out int depositAccountNumber) && accounts.ContainsKey(depositAccountNumber))
                    {
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            accounts[depositAccountNumber].Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;

                case "3": // Withdraw
                    Console.Write("Enter account number: ");
                    if (int.TryParse(Console.ReadLine(), out int withdrawAccountNumber) && accounts.ContainsKey(withdrawAccountNumber))
                    {
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            accounts[withdrawAccountNumber].Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;

                case "4": // Check Balance
                    Console.Write("Enter account number: ");
                    if (int.TryParse(Console.ReadLine(), out int checkAccountNumber) && accounts.ContainsKey(checkAccountNumber))
                    {
                        accounts[checkAccountNumber].ShowBalance();
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;

                case "5": // Exit
                    Console.WriteLine("Thank you for using the Banking System!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
