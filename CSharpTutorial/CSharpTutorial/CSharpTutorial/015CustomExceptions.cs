using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSharpTutorial
{

    //    Summary for Interview
    // Why we create Custom Exceptions ?
    //"We create custom exceptions when we need to handle specific business failures (like PaymentFailed) differently from technical crashes. 
    //It allows us to catch specific issues and recover gracefully, 
    //and it lets us attach relevant data(like TransactionId) directly to the exception object."

    public class CustomExceptions : Exception
    {
        // 1. Add Custom Properties for Filtering
        public int ErrorCode { get; }
        public bool CanRetry { get; }
        public CustomExceptions(int age, int errorCode=1, bool canRetry=false) : base($"Age Should be greater than 18. Your Age is {age}")
        {
            ErrorCode = errorCode;
            CanRetry = canRetry;
        }
    }

    public class ExceptionTest
    {
        public bool RegisterUser(int Age)
        {
            if (Age < 18)
                throw new CustomExceptions(age: Age, errorCode: 101, canRetry: true);
            else
                return true;

        }
    }


}
