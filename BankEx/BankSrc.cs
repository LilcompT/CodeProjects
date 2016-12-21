using System;

namespace ConsoleApplication
{
    public class BankCore
    {
        public static void Main(string[] args)
        {
            
        }
    }

    public abstract class Account
    {
        // Widthrawal Method
        public abstract void Withdraw(double cashAmt);
        // Deposit Method
        public abstract void Deposit(double cashAmt);
        // Loan Method
        public abstract void Loan(double cashAmt);
    }

    public class CurrentAcc : Account
    {
        
    }
}
