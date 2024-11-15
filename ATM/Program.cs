using ATM;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

public class Program
{
    public static void Main(string[] args)
    {

        List<Account> accounts = new List<Account>();

        Console.WriteLine("Welcome to the ATM!");

        bool loggedIn = false;
        string username;
        string pin;
        bool userFound = false;
        Account currentAcc = new Account(null, null);

        while (!loggedIn)
        {
            Console.WriteLine("Enter username:");
            username = Console.ReadLine();
            
            foreach (Account account in accounts)
            {
                if (username == account.GetUsername())
                {
                    userFound = true;
                    Console.WriteLine("Enter PIN:");
                    pin = Console.ReadLine();
                    if (pin == account.GetPin())
                    {
                        loggedIn = true;
                        Console.WriteLine("Authentication success!");
                        currentAcc = account;
                    }
                    else
                    {
                        Console.WriteLine("Authentication failed!");
                    }
                    break;
                }
            }
            if (!userFound)
            {
                Console.WriteLine("Username not found. Do you want to create a new account? 1: Create new account, 2: Try another username");
                string choice = Console.ReadLine();
                if (choice.Equals("1")) 
                {
                    Console.WriteLine("Set password for " + username + " :");
                    string newPin = Console.ReadLine();
                    Account newAcc = new Account(username, newPin);
                    accounts.Add(newAcc);
                    Console.WriteLine("Account created! Returning to main screen.");

                }
                
            }

        }

        string menuChoice = "";
        while (!menuChoice.Equals("4"))
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Exit");

            menuChoice = Console.ReadLine();

            if (menuChoice.Equals("1"))
            {
                Console.WriteLine("Your balance is: " + currentAcc.GetBalance() + "$");
            }
            else if (menuChoice.Equals("2"))
            {
                Console.WriteLine("Enter ammount to deposit:");
                int ammountToDeposit = int.Parse(Console.ReadLine());
                currentAcc.Deposit(ammountToDeposit);
                Console.WriteLine("Deposit successful! Your new balance is: " + currentAcc.GetBalance() + "$");
            }
            else if (menuChoice.Equals("3"))
            {
                Console.WriteLine("Enter ammount to withdraw:");
                int ammountToWitdraw = int.Parse(Console.ReadLine());
                bool success = currentAcc.Withdraw(ammountToWitdraw);
                if (success)
                {
                    Console.WriteLine("Withdrawal successful! Your new balance is: " + currentAcc.GetBalance() + "$");
                }
                else
                {
                    Console.WriteLine("Insufficient funds. Your current balance is: " + currentAcc.GetBalance() + "$");
                }
            }

        }
        //exit


    }     

}