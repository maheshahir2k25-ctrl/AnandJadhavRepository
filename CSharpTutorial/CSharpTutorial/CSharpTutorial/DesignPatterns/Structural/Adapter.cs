using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns.Structural
{
    //Our Interface
    public interface IVehicle
    {
        void Deliver();
    }

    //Third party class
    public class  Drone
    {
        public void Beep()
        {
            Console.WriteLine("Beep Beep! Drone is ready.");
        }   
        public void Fly()
        {
            Console.WriteLine("Flying the drone to deliver the package.");
        }
    }

    public class DroneAdapter : IVehicle
    {
        private readonly Drone _drone;
        public DroneAdapter(Drone drone)
        {
            _drone = drone;
        }
        public void Deliver()
        {
            _drone.Beep();
            _drone.Fly();
        }
    }

    public class AdapterPatternTest
    {
        public void Main()
        {
            IVehicle myDrone = new DroneAdapter(new Drone());
            myDrone.Deliver();
        }
    }   



}
