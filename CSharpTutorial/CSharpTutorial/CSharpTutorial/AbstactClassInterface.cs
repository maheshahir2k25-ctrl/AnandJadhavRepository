using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{

    public interface IMyInterface
    {
        int MyProperty { get; set; }
        void MyMethod();
        void MyMethod1();
        void MyMethod2();
    }

    public abstract class MyAbstractClass : IMyInterface
    {
        public MyAbstractClass(int myproperty)
        {
            MyProperty = myproperty;
        }

        public abstract int MyProperty { get; set; }
        public abstract void MyMethod();
        public abstract void MyMethod1();
        public abstract void MyMethod2();
       
    }

    public class MyClass : MyAbstractClass
    {
        public MyClass() : base(10)
        { 
        
        }
        public override int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void MyMethod()
        {
            throw new NotImplementedException();
        }

        public override void MyMethod1()
        {
            throw new NotImplementedException();
        }

        public override void MyMethod2()
        {
            throw new NotImplementedException();
        }
    }

}
