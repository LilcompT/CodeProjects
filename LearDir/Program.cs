using System;

namespace LearnApplicationVol1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            /*VehicleInterfaceWork veh = new VehicleInterfaceWork();
            veh.SetName = "bob";
            veh.EngineType();

            Nullables nullType = new Nullables();
            nullType.NullValuesTest();

            PrintOverload p = new PrintOverload();
            p.PrintData(5);
            p.PrintData(5.5);
            p.PrintData("Five");*/

            Multiples mul = new Multiples();

            mul.Multi3();
        }
    }
    // FUNCTION OVERLOADING
    class PrintOverload
    {
        public void PrintData(int i)
        {
            Console.WriteLine("INT is: " + i);
        }

        public void PrintData(double j)
        {
            Console.WriteLine("DOUBLE is: " + j);
        }

        public void PrintData(string k)
        {
            Console.WriteLine("STRING is: " + k);
        }
    }

    // NULLABLES
    class Nullables
    {
        double? num1 = 1.10;
        double? num2 = 3.141;
        double? num3;

        public void NullValuesTest()
        {
            num3 = num1 ?? 5.43;
            Console.WriteLine("From num1 " + num3);
            num3 = num2 ?? 5.43;
            Console.WriteLine("From num2 " + num3);
        }
    }

    // INTERFACE
    interface ITest
    {
        string SetName
        {
            set; get;
        }
        void EngineType();
    }

    class VehicleInterfaceWork : ITest
    {
        string name = "";

        public string SetName
        {
            set{ name = value; }
            get{ return name; }
        }

        public void EngineType()
        {
            Console.WriteLine("Inheriting Engine via Interface");
            Console.WriteLine(SetName);
        }
    }

    // ABSTRACT

    class Multiples
    {
        public void Multi1()
        {
            int multiCount = 1;
            int result = 0;

            for(int i = 0; i <= 12 && multiCount <= 12; i++)
            {
                if(i == 12)
                {
                    Console.WriteLine(multiCount * i + "\n");
                    i = 0;
                    ++multiCount;
                }
                else
                {
                    Console.WriteLine(multiCount * i);
                }
            }
        }

        public void Multi2()
        {
            int a;
            int b;

            Console.WriteLine();
            for (int i = 0; i < 12 * 12; ++i)
            {
                a = i / 12 + 1;
                b = i % 12 + 1;
                Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
            }
        }

        public void Multi3()
        {
            int col;
            int row;

            for(row = 1; row <= 12; row++)
            {
                for(col = 1; col <=12; col++)
                {
                    Console.WriteLine("{0}\t", row*col);
                }
                
                Console.WriteLine("\n");
            }
        }
    }
}
