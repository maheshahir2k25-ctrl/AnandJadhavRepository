using CSharpTutorial.DesignPatterns.FactoryMethod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSharpTutorial.DesignPatterns.Structural
{
    //    Pattern 6: The Facade Pattern
    //Category: Structural
    //1. The Concept(Simple English)
    //Imagine you want to start a car.
    //You don't have to manually inject fuel, ignite the spark plugs, and open the air intake valves.
    //You just press one button: "Start".
    //The "Start Button" is a Facade(a mask/face). It hides the messy, complex system behind a simple interface.
    //The Rule: Provide a unified interface to a set of interfaces in a subsystem.Facade defines a higher-level interface that makes the subsystem easier to use.

    //2. The Problem (Complexity)
    //Sticking to our Logistics theme: To ship an order, you might have to interact with three different systems.

    //C#
    //// Without Facade, the Client (Main) has to do all this hard work:
    //InventorySystem inventory = new InventorySystem();
    //    inventory.CheckStock();

    //PaymentSystem payment = new PaymentSystem();
    //    payment.ProcessPayment();

    //ShippingSystem shipping = new ShippingSystem();
    //    shipping.ScheduleDispatch();
    //If you have to write these 3 lines everywhere in your app, it is messy.


    //3. The Subsystems(The "Messy" Parts)
    //These are the complex classes we want to hide.
    public class InventorySystem
    {
        public bool CheckStock() { Console.WriteLine("Order Received. Stock is available"); return true; }
    }

    public class PaymentSystem
    {
        public bool ProcessPayment() { Console.WriteLine("Payment Processed Successfully"); return true; }
    }

    public class ShippingSystem
    {
        public void ShipOrder() => Console.WriteLine("Order Shipped");
    }

    //4. The Facade(The Simple "Face")
    //We create one class that does the coordination for us.
    public class OrderFacade
    {
        private readonly InventorySystem _inventory;
        private readonly PaymentSystem _payment;
        private readonly ShippingSystem _shipping;
        public OrderFacade(InventorySystem inventory, PaymentSystem payment, ShippingSystem shipping)
        {
            _inventory = inventory;
            _payment = payment;
            _shipping = shipping;
        }
        public void PlaceOrder()
        {
            if (!_inventory.CheckStock())
            {
                Console.WriteLine("Order Failed: Stock Unavailable");
                return;
            }
            if (!_payment.ProcessPayment())
            {
                Console.WriteLine("Order Failed: Payment Processing Error");
                return;
            }
            _shipping.ShipOrder();
            Console.WriteLine("Order Completed Successfully");
        }
    }

    public class FacadePatternTest
    {
        public void Main()
        {
            InventorySystem inventory = new InventorySystem();
            PaymentSystem payment = new PaymentSystem();
            ShippingSystem shipping = new ShippingSystem();
            OrderFacade orderFacade = new OrderFacade(inventory, payment, shipping);
            orderFacade.PlaceOrder();
        }
    }
}

//The Best Choice
//When to use it: When you have a complex system (legacy code, 3rd party libraries) and you want to provide a simple entry point for your team.

//Difference from Adapter:

//Adapter makes two incompatible interfaces match.

//Facade makes a complex interface simpler.