using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class BankCore
    {

        private static List<UserAccountManagement> accountList = new List<UserAccountManagement>();
        private static int userID = 0;

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
            Console.WriteLine("2. New Member");
            Console.WriteLine("3. Exit\n");
            Console.Write("Option: ");
            optionInput = Int32.Parse(Console.ReadLine());
            
            if(optionInput == 1)
            {
                if(Authentication() == true)
                {
                    DisplayMainInterface(userID);
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }
            else if(optionInput == 2)
            {
                AddNewUser();
                DisplayMainInterface(userID);
            }
            else if(optionInput ==  3)
            {
                //System exit
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
           int index = 0;
           
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
                       userID = index;
                       return true;
                   }

                   ++index;
               }
               attempt++;
           }
           return false;
        }
        private void DisplayMainInterface(int userID)
        {
            int OptionInput = 0;
            int ID = userID;
            double cashInput = 0.0;
            const int currentAccType = 1;
            const int savingAccType = 2;
            bool taskNotFinished = true;

            Console.WriteLine("1. View Account\t\t\t\t2. Deposit Cash");
            Console.WriteLine("3. Widthraw Cash\t\t\t4. Log Out");

            OptionInput = Int32.Parse(Console.ReadLine());
            while(taskNotFinished)
            {
                switch(OptionInput)
                {
                    case 1:
                        accountList[userID].ViewAccount(++ID);
                        taskNotFinished = false;
                        DisplayMainInterface(userID);
                        break;
                    case 2:
                        Console.Write("\nAmount to Deposit: ");
                        cashInput = double.Parse(Console.ReadLine());
                        
                        if(accountList[userID].accountType == currentAccType)
                        {
                            accountList[userID].Deposit(cashInput, currentAccType);
                        }
                        else if(accountList[userID].accountType == savingAccType)
                        {
                            accountList[userID].Deposit(cashInput, savingAccType);
                        }
                        
                        taskNotFinished = false;
                        DisplayMainInterface(userID);
                        break;
                    case 3:
                        Console.Write("\nAmount to Widthraw: ");
                        cashInput = double.Parse(Console.ReadLine());
                        
                        if(accountList[userID].accountType  == currentAccType)
                        {
                            accountList[userID].Withdraw(cashInput, currentAccType);
                        }
                        else if(accountList[userID].accountType == savingAccType)
                        {
                            accountList[userID].Withdraw(cashInput, currentAccType);
                        }

                        taskNotFinished = false;
                        DisplayMainInterface(userID);
                        break;
                    case 4:
                        BankFront();
                        taskNotFinished = false;
                        
                        break;
                }
            }
        }
    }

    public abstract class Account
    {
        // Widthrawal Method
        public abstract void Withdraw(double cashAmt, int accountType);
        // Deposit Method
        public abstract void Deposit(double cashAmt, int accountType);

        public abstract void ViewAccount(int accountType);
    }

    class UserAccountManagement : Account
    {
       private  string name;
       private string passcode;
       private int accType;
       private double currentBalance = 1000.00;
       private double savingBalance = 900.00;

       public UserAccountManagement()
       {

       }
       public  UserAccountManagement(string name, string passcode, int accType)
       {
           this.name = name;
           this.passcode = passcode;
           this.accType = accType;
       }

       public override void Deposit(double cashAmt, int accountType)
       {
           if(accountType == 1)
           {
               currentBalance += cashAmt; 
           }
           else if(accountType == 2)
           {
               savingBalance += cashAmt;
           }
       }

       public override void Withdraw(double cashAmt, int accountType)
       {
           if(accountType == 1)
           {
               currentBalance -= cashAmt;
           }
           else if(accountType == 2)
           {
               savingBalance -= cashAmt;
           }
       }

       public override void ViewAccount(int inputAccount)
       {   
           if(inputAccount == accType)
           {
               Console.WriteLine("Name: {0} Account Type: {1} Balanace Remaining: {2}", name, accType, currentBalance);
           }
           else if(inputAccount == accType)
           {
               Console.WriteLine("Name: {0} Account Type: {1} Balanace Remaining: {2}", name, accType, savingBalance);
           }
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

       public int accountType
       {
           get
           {
               return accType;
           }
       }
    }
}
