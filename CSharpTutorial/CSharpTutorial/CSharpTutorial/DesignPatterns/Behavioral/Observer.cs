using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CSharpTutorial.DesignPatterns.Behavioral
{
    // 1. The Concept
    //This is the "YouTube Subscription" pattern.

    //Publisher(Subject): The YouTube Channel.

    //Subscriber(Observer): The User.

    //When the Channel uploads a new video, it doesn't call every user individually by name. It just sends a "Notification" to everyone who subscribed. If you unsubscribe, you stop getting messages.

    //The Rule: Define a one-to-many dependency so that when one object changes state, all its dependents are notified and updated automatically.

    //2. The Problem (Why we need it)
    //Imagine you are tracking a Shipment.

    //The Customer wants to know when it arrives.

    //The Warehouse wants to know when it arrives.

    //The Insurance Company wants to know when it arrives.

    //Without Observer (Polling): The Customer has to check the website every 5 minutes: "Is it here? Is it here? Is it here?" (This wastes resources).

    //With Observer(Push): The Shipment says: "I will tell you when I arrive. Don't call me."

    //3. The Solution in Code
    //We need two Interfaces:

    //ISubscriber(Observer) : "I want to be notified."

    //ISubject(Publisher) : "I have a list of people to notify."

    public interface ISubscriber
    {
        void Update(string message);
    }
    public interface IPublisher
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Notify();
    }

    public class Customer : ISubscriber
    {
        public string Name { get; private set; }
        public Customer(string name)
        {
            Name = name;
        }
        public void Update(string message)
        {
            Console.WriteLine($"Hello {Name}, New Notification: {message}");
        }

    }

    public class WareHouse : ISubscriber
    {
        public string Location { get; private set; }
        public WareHouse(string location)
        {
            Location = location;
        }
        public void Update(string message)
        {
            Console.WriteLine($"Warehouse at {Location} received update: {message}");
        }

    }

    public class Shipment : IPublisher
    {
        string Status;
        private List<ISubscriber> _subscribers = new List<ISubscriber>();
        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }
        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this.Status);
            }
        }
        public void UpdateLocatiion(string newLocation)
        {
            this.Status = newLocation;
            Console.WriteLine($"Shipment moved to new Location: {newLocation}");
            Notify();
        }
    }

    public class ObserverPatternTest
    {
        public void Execute()
        {
            Shipment shipment = new Shipment();
            Customer customer1 = new Customer("Mahesh");
            Customer customer2 = new Customer("Sandeep");
            WareHouse warehouse1 = new WareHouse("Mumbai Warehouse");
            shipment.Subscribe(customer1);
            shipment.Subscribe(customer2);
            shipment.Subscribe(warehouse1);

            shipment.UpdateLocatiion("Mumbai");
            shipment.UpdateLocatiion("Pune");
            shipment.Unsubscribe(customer1);
            shipment.UpdateLocatiion("Banglore");
        }
    }


}
