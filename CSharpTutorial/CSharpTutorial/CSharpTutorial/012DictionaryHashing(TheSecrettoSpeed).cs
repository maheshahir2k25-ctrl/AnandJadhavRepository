using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{

    public class User
    {
        public string Name { get; set; }
        public string Address { get; set; }


    }

    public class DictionaryHashingExample
    {
        

        // Scenario: We have 1 Million Users
        Dictionary<string, User> userDict = new Dictionary<string, User>();
        // ... assume we filled it with 1 million users ...

        // 1. THE HASH WAY (Dictionary)
        // C# calculates the hash of "user999999" -> gets index 500 -> Jumps there.
        // Time taken: 0.00001 ms (Instant)
        //User u = userDict["user999999"];

        // 2. THE LIST WAY (Linear Search)
        // C# has to check: Is index 0 "user999999"? No. Index 1? No... Index 999998? No.
        // Time taken: Slower (proportional to list size)

    }
}
