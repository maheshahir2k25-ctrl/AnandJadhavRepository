using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns.FactoryMethod
{
    public interface IVehicle
    {
        void Deliver();
    }

    public class Truck : IVehicle
    {
        public void Deliver() => Console.WriteLine("Delivering by Truck");
    }

    public class Ship : IVehicle
    {
        public void Deliver() => Console.WriteLine("Delivering by Ship");
    }

    public abstract class Logistics
    {
        public abstract IVehicle CreateVehicle();

        public void PlanDelivery()
        {
            IVehicle vehicle = CreateVehicle();
            vehicle.Deliver();
        }
    }

    public class RoadLogistics : Logistics
    {
        public override IVehicle CreateVehicle() => new Truck();
    }
    public class SeaLogistics : Logistics
    {
        public override IVehicle CreateVehicle() => new Ship();
    }

    public class FactoryMethodTest
    {
        public void Main()
        {
            Logistics myLogistics = new RoadLogistics();
            myLogistics.PlanDelivery();

            myLogistics = new SeaLogistics();
            myLogistics.PlanDelivery();

        }
    }

}