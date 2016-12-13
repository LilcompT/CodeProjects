using System;

namespace InterfaceExampleApplication
{
    public class Vehicle
    {
        public static void Main(string[] args)
        {
            VehicleWork veh = new VehicleWork();
            veh.SetName = "bob";
            veh.EngineType();
            
        }
    }

    interface ITest
    {
        string SetName
        {
            set; get;
        }
        void EngineType();
    }

    class VehicleWork : ITest
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
}
