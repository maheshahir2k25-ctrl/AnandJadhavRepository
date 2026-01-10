using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpTutorial.DelegatesExample;

namespace CSharpTutorial
{
    //Delegate Example
    //Delegate is a type that represents references to methods with a specific parameter list and return type.
    //Custom delegate that takes two integers and returns an integer
    public delegate int MyDelegate(int x, int y);
    public class DelegatesExample
    {


        public int AddNumbers1(int a, int b)
        {
            return a + b;
        }
        public int AddNumbers4(int a, int b)
        {
            return a + b;
        }

        public void Run()
        {
            MyDelegate del = new MyDelegate(AddNumbers1);
            MyDelegate del2 = AddNumbers1;

            int result = del(5, 10);
            Console.WriteLine("Result: " + result);

            del = new MyDelegate(AddNumbers4);
            result = del(5, 10);
            Console.WriteLine("Result: " + result);

            DelegateAsFunctionParameter obj = new DelegateAsFunctionParameter();
            obj.MethodWithAnothermethhodAsaParameter(AddNumbers2);//Method as a parameter 

        }

        //Func delegate that takes an int and returns a bool
        Func<int, bool> isEven = x => x % 2 == 0;

        //Question Convert following method into Func delegate
        public int AddNumbers2(int a, int b)
        {
            return a + b;
        }
        //Answer
        Func<int, int, int> AddNumbers = (x, y) => x + y;

        //Question Convert following method into Action delegate
        public void Execute(int x, int y)
        {
            x = x / y;
        }
        //Answer
        Action<int, int> AddNumbers3 = (x, y) => x = x / y;

        Action Myaction = () => { int a = 5; int b = 10; int c = a + b; };
        Func<int, int, bool> MyFunc = (x, y) => x > y;


    }
    public class DelegateAsFunctionParameter
    {

        public void MethodWithAnothermethhodAsaParameter(MyDelegate myDelegate)
        {

            myDelegate(1, 2);//Callback Method

        }

    }

    public class DelegateExample2
    {
        // 1. DECLARE DELEGATE
        // "I need a method that takes a number and returns true (keep it) or false (discard it)."
        public delegate bool FilterLogic(int number);

        Action<int, int, int, int, int> Myaction;// It accept functions with no return type and same type and number of arguments
        Func<int, int, int, int, int> MyFunc;

        public void MyTestFunctionAction(int i, int j, int k, int l, int m)
        {
            Action logger = TestFunctionforAction;
        }

        public int MyTestFunction(int i, int j, int k, int l)
        {
            return 1;
        }

        public void TestFunctionforAction()
        {

        }


        public int i = 10;
        public int MyProperty { get; set; }
        public void Main()
        {
            Myaction = MyTestFunctionAction;

            MyFunc = MyTestFunction;

            List<int> numbers = new List<int> { 5, 12, 20, 3, 8, 33 };

            Console.WriteLine("--- Filter: Even Numbers ---");
            // Pass the 'IsEven' method as a parameter
            ProcessList(numbers, IsEven);

            Console.WriteLine("\n--- Filter: Large Numbers (> 10) ---");
            // Pass the 'IsLarge' method as a parameter
            ProcessList(numbers, IsLarge);

            // Note: 'ProcessList' logic never changed! 
            // We just injected different "brains" into it.
        }

        // 2. THE HELPER METHOD (The Logic)
        // This is the "Brain" we will pass around.
        public bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        public bool IsLarge(int n)
        {
            return n > 10;
        }

        // 3. THE GENERIC PROCESSOR (The Worker)
        // It accepts a List AND a Delegate (logic).
        public void ProcessList(List<int> list, FilterLogic logic)
        {
            foreach (int num in list)
            {
                // We don't write "if (num > 10)" here.
                // We ask the delegate: "Does this number pass your test?"
                if (logic(num) == true)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }


    ///Multicast Delegates
    public class MulticastDelegateSample
    {
        public delegate int TestDelegate(int x, int y);
        public TestDelegate testDelegate;
        public MulticastDelegateSample()
        {
        }
    }

    public class DelegateMain
    {
        public MulticastDelegateSample eventsSample;

        public DelegateMain(int x, int y)
        {
            eventsSample = new MulticastDelegateSample();
            eventsSample.testDelegate = MyFunction;
            eventsSample.testDelegate += MyFunction2;
            eventsSample.testDelegate(x, y);
        }

        public int MyFunction(int a, int b)
        {
            //eventsSample.testDelegate = null;
            return a + b;
        }

        public int MyFunction2(int a, int b)
        {
            eventsSample.testDelegate(1, 2);
            return a + b;
        }

    }

    public class TestDelegateUser
    {
        DelegateMain delegateMain;

        public TestDelegateUser()
        {
            delegateMain = new DelegateMain(10, 20);
        }

    }

}
