using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpTutorial
{
    public class ExtensionMethodExample
    {

        public void Execute()
        {
            string name = "Anand";
            string fullname = name.AddLastNameJadhav();
            fullname = "Mahesh".AddLastNameJadhav();


            ExplicitInterfaceImplementation obj = new ExplicitInterfaceImplementation();
            double total = obj.AddNumberToExistingNumber(5);
        }

    }


    public static class Extensions
    {

        public static string AddLastNameJadhav(this string FirstName)
        {

            return FirstName = FirstName + " Jadhav";

        }

        public static double AddNumberToExistingNumber(this ExplicitInterfaceImplementation obj, double x)
        {

            return obj.PI + x;
        }


    }


}
