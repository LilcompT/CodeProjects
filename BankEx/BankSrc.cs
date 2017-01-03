using System;

namespace ConsoleApplication
{
    public class BankCore
    {
        public static void Main(string[] args)
        {
            CurrentAcc curr = new CurrentAcc();    
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
        private double custCurrBalance;
        public override void Withdraw(double cashAmt)
        {
            custCurrBalance -= cashAmt;
            Console.WriteLine("New balance: " + custCurrBalance);
        }

        public override void Deposit(double cashAmt)
        {
            custCurrBalance =+ cashAmt;
            Console.WriteLine("New balance: " + custCurrBalance);
        }

        public override double ViewAcc()
        {
            return custCurrBalance;
        }
    }

    class SavingsAcc : Account
    {
       private double custSavBalance;
        public override void Withdraw(double cashAmt)
        {
            custSavBalance -= cashAmt;
            Console.WriteLine("New balance: " + custSavBalance);
        }

        public override void Deposit(double cashAmt)
        {
            custSavBalance =+ cashAmt;
            Console.WriteLine("New balance: " + custSavBalance);
        }

        public override double ViewAcc()
        {
            return custSavBalance;
        }

    }
}
