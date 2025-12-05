using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    internal class Class1
    {
        public Class1() {

        }

        public void SetNameAndAge(IMyInterface myObj)
        {
            if (myObj != null)
            {
                myObj.GetName();
                myObj.GetAge();
            }
        }

        
    }
}


//INotifyPropertyChangeWindow objINotiifyPropertyChange = new INotifyPropertyChangeWindow();
//objINotiifyPropertyChange.GetName();
//objINotiifyPropertyChange.GetAge();

//MainWindow mainWindow = new MainWindow();
//mainWindow.GetName();
//mainWindow.GetAge();

//IMyInterface myInterface = new INotifyPropertyChangeWindow();
//myInterface.GetName();
//myInterface.GetAge();
