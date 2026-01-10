using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{

   
    public class TryCatchFinally
    {

        public bool Execute()
        {
            try
            {
                return this.MyMethod2();
            }
            catch (Exception ex)
            { 
            
            }
            return true;
        }


        public bool MyMethod2()
        {
            try
            {
                return this.MyMethod();

            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw;
            }
        }

        public bool MyMethod()
        {
            try
            {

                List<string> MyList = new List<string>();
                for (int i = 0; i < 100; i++)
                {
                    string mystring = MyList[i];
                }

                return true;

            }
            catch (ArgumentOutOfRangeException ex4)      
            {
                string linenumber = ex4.StackTrace.Substring(ex4.StackTrace.Length - 7);
                
                Debug.WriteLine($"Something Went Wrong: Method Name MyMethod() at line {linenumber} \n {ex4.Message}");
                ExceptionDispatchInfo.Capture(ex4).Throw();

            }
            catch (InvalidOperationException ex)
            {
                
            }

            catch (IndexOutOfRangeException ex2)
            {
                //throw;//throw Exception details with stackTrace
            }
            catch (Exception ex1)
            {
                throw ex1;//throw Exception details without stackTrace
            }
            finally
            {

            }
            return true;

        }

        public class AgeParser
        {
            public int Parse(string data)
            {
                return 1;
            }
        }
        public void ReadUserAge()
        {
            try
            {
                string data = System.IO.File.ReadAllText("age.txt");

                // BUG INTRODUCED ON PURPOSE:
                // We forgot to initialize this class!
                AgeParser parser = null;

                // This line throws a NullReferenceException (A critical bug)
                int age = parser.Parse(data);

                Console.WriteLine($"User is {age} years old.");
            }
            catch (NullReferenceException ex1)
            {
                // The code reaches here even though the file exists!
                // We just swallowed a NullReferenceException.
                Console.WriteLine(ex1.Message);
            }
            // ❌ BAD: We catch ALL errors, assuming it's a file issue.
            catch (Exception ex)
            {
                // The code reaches here even though the file exists!
                // We just swallowed a NullReferenceException.
                Console.WriteLine("Could not read file. Please check if file exists.");
            }
        }
    }
}
