using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Threading;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
namespace CSharpTutorial
{
    public class AsyncAwaitTask
    {

        //CPU Bound vs.I/O Bound
        //This is the most important distinction.
        //I/O Bound (Database, File, Web API): The CPU is doing nothing; it's just waiting for a hard drive or network cable.
        //Solution: Use await.Do NOT use Task.Run.
        //CPU Bound (Image Processing, Complex Math): The CPU is working hard.
        //Solution: Use Task.Run to move this work to a background thread so the UI doesn't freeze.

        public int LongRunningOperation()
        {
            int i = 0;
            for (; i <= 100000;)
            {
                i++;
                //update Some UI OR Some Service Call
            }
            return i;
        }



        public void ExecuteAsyncUsingTask()
        {
            //CPU Bound Operation
            Task.Run(() =>
             {
                 int j = 0;
                 for (; j <= 10000;)
                 {
                     UpdateUI(j++);
                     //this.Title = j++.ToString();//This will give error as we are trying to update UI element from non UI thread
                 }
             });
        }

        public void UpdateUI(int j)
        {
            //if (!System.Windows.Threading.DispatcherObject.CheckAccess())
            //{
            //    // On a different thread
            //    Dispatcher.Invoke(() => UpdateUI(j));
            //    return;
            //}
            //this.Title = j.ToString();
        }

        //I/O Bound Operation
        public async Task ExecuteUsingAsync()
        {
            await SomeDatabaseCall();
        }


        public async Task SomeDatabaseCall()
        {
            //Simulating Database Call
            await Task.Delay(5000);

        }
    }
}
