using System;

namespace LearnApplicationVol1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            VehicleInterfaceWork veh = new VehicleInterfaceWork();
            veh.SetName = "bob";
            veh.EngineType();

            Nullables nullType = new Nullables();
            nullType.NullValuesTest();

            PrintOverload p = new PrintOverload();
            p.PrintData(5);
            p.PrintData(5.5);
            p.PrintData("Five");
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
}
