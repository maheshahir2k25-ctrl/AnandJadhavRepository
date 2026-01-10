using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns.Structural.Decorator
{
    public interface IVehicle
    {
        string Deliver();
    }

    public class Truck : IVehicle
    {
        public string Deliver() => "Delivering by Truck";
    }

    // Base Decorator
    public abstract class VehicleDecorator : IVehicle
    {
        protected IVehicle _vehicle;
        public VehicleDecorator(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        public virtual string Deliver()
        {
            return _vehicle.Deliver();
        }
    }

    public class RefrigeratedTruck : VehicleDecorator
    {
        public RefrigeratedTruck(IVehicle vehicle) : base(vehicle)
        {

        }
        public override string Deliver()
        {
            string result = base.Deliver();
            return $"{result} with Refrigeration";
        }
    }

    public class ArmoredTruck : VehicleDecorator
    {
        public ArmoredTruck(IVehicle vehicle) : base(vehicle)
        {
        }
        public override string Deliver()
        {
            string result = base.Deliver();
            return $"{result} with Armored Protection";
        }

    }

    public class DecoretorTest
    {
        public void Main()
        {
            IVehicle Truck = new Truck();
            Console.WriteLine("-----------------Simple Truck-------------------------------");
            Console.WriteLine(Truck.Deliver());

            Console.WriteLine("-----------------Refridgerated Truck-------------------------------");
            IVehicle RefrigeratedTruck = new RefrigeratedTruck(Truck);
            Console.WriteLine(RefrigeratedTruck.Deliver());

            Console.WriteLine("-----------------Refridgerated Armored Truck-------------------------------");
            IVehicle ArmoredRefrigeratedTruck = new ArmoredTruck(RefrigeratedTruck);
            Console.WriteLine(ArmoredRefrigeratedTruck.Deliver());

        }

    }


}
