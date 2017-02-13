using System;

namespace LearnCode
{
    class TestEnum
    {
        static void Main(string[] args)
        {
            //TestEnum test = new TestEnum();
            //test.EnumTest(Type.file);

            FactorialTest factTest1 = new FactorialTest();
            Console.WriteLine("Recursive Factorial: {0}", factTest1.RecursiveFactorial(5));
            Console.WriteLine("Iterative Factorial: {0}", factTest1.IterativeFactorial(5));
        }

        public enum Type {file, size, date, modified};

        public void EnumTest(Type criteria)
        {
            switch(criteria)
            {
                case Type.file:
                    Console.WriteLine("Sorting by File");
                    break;
                case Type.size:
                    Console.WriteLine("Sorting by Size");
                    break;   
                case Type.date:
                    Console.WriteLine("Sorting by Date");
                    break;
                case Type.modified:
                    Console.WriteLine("Sorting by modified");
                    break;      
            }
        }
    }

    class FactorialTest
    {
        public int RecursiveFactorial(int n)
        {
            if(n == 0 || n == 1)
            {
                return 1;
            }

            return n * (RecursiveFactorial(n-1));
        }

        public int IterativeFactorial(int n)
        {
            int result = 1;

            if(n == 0 || n == 1)
            {
                return 1;
            }
            for(int i = 2; i <= n; ++i)
            {
                result = result * i;
            }

            return result;
        }
    }
}