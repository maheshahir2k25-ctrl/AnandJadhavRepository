using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{

    public interface InterfaceA
    {
        void Add();

    }

    public interface InterfaceB
    {
        void Add();
    }

    public sealed class ExplicitInterfaceImplementation : InterfaceA, InterfaceB
    {
        void InterfaceA.Add()
        {

        }
        void InterfaceB.Add()
        {

        }

       public double PI = 3.14;

    }


    public class ExplicitInterfaceTest
    {
        public void Execute()
        {
            ExplicitInterfaceImplementation obj = new ExplicitInterfaceImplementation();
            ((InterfaceA)obj).Add();
            ((InterfaceB)obj).Add();
        }


    }
}
