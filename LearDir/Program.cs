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
