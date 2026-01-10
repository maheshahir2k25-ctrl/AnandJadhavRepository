using CSharpTutorial.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns
{
    public interface IVehicle
    {
        void Deliver();
    }
    public interface IDriver
    {
        void Verify();
    }

    public class Truck : IVehicle
    {
        public void Deliver() => Console.WriteLine("Delivering by Truck");
    }
    public class TruckDriver : IDriver
    {
        public void Verify() => Console.WriteLine("Hi, I am a verified truck Driver.");
    }


    public class Ship : IVehicle
    {
        public void Deliver() => Console.WriteLine("Delivering by Ship");
    }
    public class ShipDriver : IDriver
    {
        public void Verify() => Console.WriteLine("Hi, I am a verified Ship Captain");
    }


    public abstract class LogisticsFactory
    {
        public abstract IVehicle CreateVehicle();
        public abstract IDriver AssignDriver();

        public void PlanDelivery()
        {
            IVehicle vehicle = CreateVehicle();
            IDriver driver = AssignDriver();
            driver.Verify();
            vehicle.Deliver();
        }
    }

    public class RoadLogistics : LogisticsFactory
    {
        public override IVehicle CreateVehicle() => new Truck();
        public override IDriver AssignDriver() => new TruckDriver();
    }
    public class SeaLogistics : LogisticsFactory
    {
        public override IVehicle CreateVehicle() => new Ship();
        public override IDriver AssignDriver() => new ShipDriver();
    }

    public class AbstractFactoryPatternExample
    {
        public void TestAbstractFacotory()
        {
            LogisticsFactory myLogistics = new RoadLogistics();
            myLogistics.PlanDelivery();

            myLogistics = new SeaLogistics();
            myLogistics.PlanDelivery();

        }
    }
}