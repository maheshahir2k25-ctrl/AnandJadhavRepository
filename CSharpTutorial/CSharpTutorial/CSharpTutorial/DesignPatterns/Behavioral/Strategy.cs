using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns.Behavioral
{
    //Pattern 8: The Strategy Pattern
    //Category: Behavioral

    //1. The Concept(Simple English)
    //Imagine using Google Maps.You enter a destination.

    //Google asks: "How do you want to go?"

    //Car? (Standard speed, road usage)

    //Walking? (Uses sidewalks, parks)

    //Public Transport? (Uses bus stops, trains)

    //The Result is the same(Getting from A to B), but the Algorithm(The logic) is completely different.

    //The Rule: Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

    //2. The Problem (The "If-Else" Hell)
    //Without Strategy, your code looks like this:

    //C#

    //public void CalculateRoute(string type)
    //    {
    //        if (type == "Road")
    //        {
    //            // 50 lines of code for Road logic...
    //        }
    //        else if (type == "Sea")
    //        {
    //            // 50 lines of code for Sea logic...
    //        }
    //        else if (type == "Air")
    //        {
    //            // 50 lines of code for Air logic...
    //        }
    //    }
    //    If you add "Drone" later, you have to break this file open and edit it (violating the Open/Closed Principle).

    //3. The Solution in Code (Swapping Logic)
    //We create a common interface IRouteStrategy. Then we put each algorithm in its own class.


    public interface IRouteStrategy
    {
        void BuildRoute(string from, string to);
    }

    public class RoadStrategy : IRouteStrategy
    {
        public void BuildRoute(string from, string to)
        {
            Console.WriteLine($"Building Road Route from {from} to {to}");
        }
    }

    public class SeaStrategy : IRouteStrategy
    {
        public void BuildRoute(string from, string to)
        {
            Console.WriteLine($"Building Sea Route from {from} to {to}");
        }
    }

    public class AirStrategy : IRouteStrategy
    {
        public void BuildRoute(string from, string to)
        {
            Console.WriteLine($"Building Air Route from {from} to {to}");
        }
    }


    public class Navigator : IRouteStrategy
    {
        private IRouteStrategy _strategy;
        public Navigator(IRouteStrategy strategy)
        {
            _strategy = strategy;
        }
        public void SetStrategy(IRouteStrategy strategy)
        {
            _strategy = strategy;
        }
        public void BuildRoute(string from, string to)
        {
            _strategy.BuildRoute(from, to);
        }
    }

    public class StrategyTest
    {
        public void Main()
        {
            Navigator navigator = new Navigator(new RoadStrategy());
            navigator.BuildRoute("Mumbai", "Pune");
            navigator.SetStrategy(new SeaStrategy());
            navigator.BuildRoute("Mumbai", "Shrilanka");
            navigator.SetStrategy(new AirStrategy());
            navigator.BuildRoute("Mumbai", "America");
        }
    }   


}
