using CSharpTutorial.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace CSharpTutorial.DesignPatterns.Behavioral
{
    //Pattern 9: The Command Pattern
    //Category: Behavioral

    //1. The Concept
    //Imagine a Universal Remote Control.

    //You have a "Button 1".
    //You want to be able to program "Button 1" to do anything: Turn on the light, Open the garage, or Start the music.
    //If you hardcode the button: if (pressed) Light.On(), then you can never change it to open the garage.

    //The Solution: You turn the Request into an Object (a Command).
    //You create a "LightOnCommand" object.
    //You hand this object to the Remote.
    //The Remote doesn't know what the object does. It just knows it has an Execute() method.

    //The Rule: Encapsulate a request as an object, letting you parameterize clients with different requests, queue or log requests, and support Undoable operations.

    //2. The Setup (The Receiver)
    //This is the actual device that does the work.

    public class Light
    {
        public void On() => Console.WriteLine("The Light is On");
        public void Off() => Console.WriteLine("The Light is Off");
    }

    public interface Icommand
    {
        void Execute();
        void Undo();
    }

    public class LightOnCommand : Icommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.On();
        }
        public void Undo()
        {
            _light.Off();
        }
    }

    public class LightOffCommand : Icommand
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.Off();
        }
        public void Undo()
        {
            _light.On();
        }
    }

    public class RemoteControl
    {
        private Icommand _command;
        public void SetCommand(Icommand command)
        {
            _command = command;
        }
        public void PressButton()
        {
            _command.Execute();
        }
        public void PressUndo()
        {
            _command.Undo();
        }
    }

    public class CommandTest
    {
        public void Main()
        {
            Light livingRoomLight = new Light();
            Icommand lightOn = new LightOnCommand(livingRoomLight);
            Icommand lightOff = new LightOffCommand(livingRoomLight);
            RemoteControl remote = new RemoteControl();
            // Turn the light on
            remote.SetCommand(lightOn);
            remote.PressButton();
            // Turn the light off
            remote.SetCommand(lightOff);
            remote.PressButton();
            // Undo the last action (turn the light back on)
            remote.PressUndo();
        }
    }


}
