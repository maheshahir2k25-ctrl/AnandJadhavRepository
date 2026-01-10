using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

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


    public interface IVoiceRecognitionStrategy
    {
        string VoiceCommandType { get; }
        void Initialize();
        void Start();
        void Pause();
        void Resume();
        void Stop();
    }

    public class OfflineRecognition : IVoiceRecognitionStrategy
    {
        public string VoiceCommandType => "Offline";

        public void Initialize()
        {
            Console.WriteLine($"Voice recogniton initialize");
        }

        public void Pause()
        {
            Console.WriteLine($"Voice recogniton Paused");
        }

        public void Resume()
        {
            Console.WriteLine($"Voice recogniton Resumed");
        }

        public void Start()
        {
            Console.WriteLine($"Voice recogniton Started");
        }

        public void Stop()
        {
            Console.WriteLine($"Voice recogniton Stopped");
        }
    }

    public class OnlineRecognition : IVoiceRecognitionStrategy
    {
        public string VoiceCommandType => "Online";
        public void Initialize()
        {
            Console.WriteLine($"Voice recogniton initialize");
        }

        public void Pause()
        {
            Console.WriteLine($"Voice recogniton Paused");
        }

        public void Resume()
        {
            Console.WriteLine($"Voice recogniton Resumed");
        }

        public void Start()
        {
            Console.WriteLine($"Voice recogniton Started");
        }

        public void Stop()
        {
            Console.WriteLine($"Voice recogniton Stopped");
        }
    }


    public class VoiceRecognitionManager : IVoiceRecognitionStrategy
    {
        private IVoiceRecognitionStrategy _strategy;

        public VoiceRecognitionManager(IVoiceRecognitionStrategy strategy)
        {
            _strategy = strategy;
        }

        public string VoiceCommandType => _strategy.VoiceCommandType;

        public void SetStrategy(IVoiceRecognitionStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Initialize()
        {
            _strategy.Initialize();
        }

        public void Pause()
        {
            _strategy.Pause();
        }

        public void Resume()
        {
            _strategy.Resume();
        }

        public void Start()
        {
            _strategy.Start();
        }

        public void Stop()
        {
            _strategy.Stop();
        }
    }

    public class VoiceRecognitionStrategyTest
    {
        public void Main(OfflineRecognition offlineRecognition, OnlineRecognition onlineRecognition)
        {
            VoiceRecognitionManager voiceManager = new VoiceRecognitionManager(offlineRecognition);
            voiceManager.Initialize();
            voiceManager.Start();
            voiceManager.Pause();

            voiceManager.SetStrategy(onlineRecognition);
            voiceManager.Initialize();
            voiceManager.Start();
            voiceManager.Pause();

            voiceManager.SetStrategy(offlineRecognition);
            voiceManager.Resume();
            voiceManager.Stop();
            
            voiceManager.SetStrategy(onlineRecognition);
            voiceManager.Stop();

        }
    }


}
