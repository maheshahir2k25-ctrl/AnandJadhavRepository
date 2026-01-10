using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DependencyProperties.Utilities
{
    public class RelayCommand : ICommand
    {
        public Action<object> ExecuteAction { get; set; }
        public Func<object, bool> CanExecuteFunc { get; set; }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
        {
            ExecuteAction = executeAction;
            CanExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            this.ExecuteAction(parameter);
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
