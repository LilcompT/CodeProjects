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

        public abstract double ViewAcc();
    }

    class CurrentAcc : Account
    {
        //Temp cust Account
        double custCurrBalance;
        public override void Withdraw(double cashAmt)
        {
            Console.WriteLine("Current Account Widthrawal Method");
        }

        public override void Deposit(double cashAmt)
        {
            Console.WriteLine("Current Account Deposit Method");
        }

        public override double ViewAcc()
        {
            return custCurrBalance;
        }
    }

    class SavingsAcc : Account
    {
        double custSavBalance;
        public override void Withdraw(double cashAmt)
        {
            Console.WriteLine("Savings Account Withdraw Method");
        }

        public override void Deposit(double cashAmt)
        {
            Console.WriteLine("Savings Account Deposit Method");
        }

        public override double ViewAcc()
        {
            return custSavBalance;
        }

    }
}
