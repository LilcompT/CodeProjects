using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class BankCore
    {
        public static void Main(string[] args)
        {
            UserAccountManagement user = new UserAccountManagement();

            user.AddNewUser();
            user.TestUser();
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

       List<UserAccountManagement> accounts = new List<UserAccountManagement>();
       
       public void AddNewUser()
       {
           string input = "";

           Console.WriteLine("Enter Full Name: ");
           input = Console.ReadLine();
           name = input;
           Console.WriteLine();
           Console.Write("Enter passcode: ");
           input = Console.ReadLine();
           passcode = input;
           Console.WriteLine();
           Console.Write("Type of Account: ");
           input = Console.ReadLine();
           accType = Int32.Parse(input);
       }

       public bool Authentication()
       {
           string loginInput = "";
           int attempt = 3;



           Console.Write("Enter name: ");
           loginInput = Console.ReadLine();

           Console.WriteLine();
           Console.Write("Enter passcode: ");
           loginInput = Console.ReadLine();

           while(attempt != 3)
           {
               // Check username and passcode against user account list
               /*
               if(loginInput == nameInList && loginInput == passcodeInList)
               {
                   return true;
               }
               else
               {
                   --attempt;
                   return false;
               } 
               */
           }

           
       }
    }
}
