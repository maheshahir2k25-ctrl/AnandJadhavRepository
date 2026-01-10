using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns.Behavioral.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();

    }

    public class Light
    {
        public void On() => Console.WriteLine("The Light is On");
        public void Off() => Console.WriteLine("The Light is Off");
    }

    public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute() => _light.On();

        public void Undo() => _light.Off();
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute() => _light.Off();
        public void Undo() => _light.On();
    }

    public class RemoteControl
    {
        // A History list to keep track of everything for Replay
        private List<ICommand> _commandHistory = new List<ICommand>();

        private ICommand _currentCommand;

       
        public void SetCommand(ICommand command)
        {
            _currentCommand = command;
        }

        public void PressButton()
        {
            _currentCommand.Execute();
            _commandHistory.Add(_currentCommand); // Add to history
        }
        public void UndoPress()
        {
            // Undo the LAST command added
            if (_commandHistory.Count > 0)
            {
                var lastCommand = _commandHistory.Last();
                lastCommand.Undo();
                _commandHistory.RemoveAt(_commandHistory.Count - 1);
            }
        }

        public void ReplayCommands()
        {
            Console.WriteLine("\n--- Replaying commands ---");

            // 1. Reset State: Undo everything in REVERSE order
            // We use Enumerable.Reverse() to go backwards
            foreach (var command in Enumerable.Reverse(_commandHistory))
            {
                command.Undo();
            }

            Console.WriteLine("(State reset complete. Now executing...)");

            // 2. Play Forward
            foreach (var command in _commandHistory)
            {
                command.Execute();
            }
        }

    }

    public class CommandPatternTest
    {
        public void Execute()
        {
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);
            LightOffCommand lightOff = new LightOffCommand(light);
            RemoteControl remote = new RemoteControl();
            remote.SetCommand(lightOn);
            remote.PressButton();
            remote.UndoPress();
            remote.SetCommand(lightOff);
            remote.PressButton();
            remote.UndoPress();

            remote.ReplayCommands();
        }
    }



}
