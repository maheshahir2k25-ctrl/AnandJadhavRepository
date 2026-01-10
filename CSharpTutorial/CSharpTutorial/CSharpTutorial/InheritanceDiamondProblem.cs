using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public abstract class A
    {
        public abstract void Sustract();

        public void Add()
        {

        }
    }

    public interface B
    {
        void Add();
    }

    public class C : A, B
    {
        //public int MyProperty { get return value; set Value=10; }

        public new void Add()
       {
            base.Add();
            this.Sustract();
            
       }

        public override void Sustract()
        {
           
        }
    }

    public class MainClass 
    {
    public void Execute() 
        {
        C c=new C();
            c.Add();
        }
    
    }
}
