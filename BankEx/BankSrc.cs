using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class BankCore
    {

        private static List<UserAccountManagement> accountList = new List<UserAccountManagement>();

        public static void Main(string[] args)
        {
            BankCore Bc = new BankCore();

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("WELCOME TO THE BANK OF LEARNING");
            Console.WriteLine("---------------------------------");

            Bc.BankFront();
        }
        
        private void BankFront()
        {
            
            int optionInput = 0;

            Console.WriteLine();
            Console.WriteLine("Please select an option");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Exsisting User");
            Console.WriteLine("2. New Member\n");
            Console.Write("Option: ");
            optionInput = Int32.Parse(Console.ReadLine());
            
            if(optionInput == 1)
            {
                if(Authentication() == true)
                {
                    DisplayMainInterface();
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }
            else if(optionInput == 2)
            {
                AddNewUser();
                DisplayMainInterface();
            }
        }

        private void AddNewUser()
        {
            string userName = "";
            string passcode = "";
            int accountType = 0;

            Console.Write("\nEnter full name: ");
            userName = Console.ReadLine();
            Console.Write("\nEnter new passcode: ");
            passcode = Console.ReadLine();
            Console.Write("\nChoose Account Type");
            Console.Write("\n1. Create Current Account\t\t 2. Create Savings Account");
            Console.Write("\nOption: ");
            accountType = Int32.Parse(Console.ReadLine());

            accountList.Add(new UserAccountManagement(userName, passcode, accountType));
        }

        public bool Authentication()
        {
           string loginName = "";
           string loginPass = "";
           int attempt = 0;
           
           Console.Write("Enter name: ");
           loginName = Console.ReadLine();
        
           Console.WriteLine();
           Console.Write("Enter passcode: ");
           loginPass = Console.ReadLine();
        
           while(attempt != 1)
           {
               foreach(UserAccountManagement user in accountList)
               {
                   if(loginName == user.UserName && loginPass == user.UserPasscode)
                   {
                       return true;
                   }
               }
               attempt++;
           }
           return false;
        }
        private void DisplayMainInterface()
        {
            int OptionInput = 0;

            Console.WriteLine("1. View Account\t\t\t\t2. Deposit Cash");
            Console.WriteLine("3. Widthraw Cash\t\t\t4. Exit");

            switch(OptionInput)
            {
                case 1: 
                    // Display user account
                    break;
                case 2:
                    // Desposit user cash into account
                    break;
                case 3:
                    // Widthraw cash from user account
                    break;
                case 4:
                    // Terminate application
                    break;
            }
        }
    }

    public abstract class Account
    {
        // Widthrawal Method
        public abstract double Withdraw(double cashAmt);
        // Deposit Method
        public abstract double Deposit(double cashAmt);

        public abstract double ViewAcc();
    }

    class CurrentAcc : Account
    {
        //Temp cust Account
        private double custCurrBalance;
        public override double Withdraw(double cashAmt)
        {
            custCurrBalance -= cashAmt;
            return custCurrBalance;
        }

        public override double Deposit(double cashAmt)
        {
            custCurrBalance =+ cashAmt;
            return custCurrBalance;
        }

        public override double ViewAcc()
        {
            return custCurrBalance;
        }
    }

    class SavingsAcc : Account
    {
       private double custSavBalance;
        public override double Withdraw(double cashAmt)
        {
            custSavBalance -= cashAmt;
            return custSavBalance;
        }

        public override double Deposit(double cashAmt)
        {
            custSavBalance =+ cashAmt;
            return custSavBalance;
        }

        public override double ViewAcc()
        {
            return custSavBalance;
        }
    }

    class UserAccountManagement
    {
       private  string name;
       private string passcode;
       private int accType;
       private double userBalance = 1000.00;

       public  UserAccountManagement(string name, string passcode, int accType)
       {
           this.name = name;
           this.passcode = passcode;
           this.accType = accType;
       }

       public string UserName
       {
           get
           {
               return name;
           }
       }

       public string UserPasscode
       {
           get
           {
               return passcode;
           }
       }

       public double MainUserBalance
       {
           get
           {
               return userBalance;
           }
           set
           {
               userBalance = value;
           }
       }

       public void Display()
       {
           Console.WriteLine("User: {0}, {1}", name, accType);
       }
    }
}
