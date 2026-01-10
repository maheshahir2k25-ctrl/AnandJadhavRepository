using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public class PerformanceTest
    {
        public void Compare()
        {
            int iterations = 1_000_000; // 1 Million items

            // -------------------------------------------------
            // 1. THE OLD WAY (ArrayList) - SLOW & UNSAFE
            // -------------------------------------------------
            ArrayList arrayList = new ArrayList();

            // BOXING happens here!
            // The int 'i' is wrapped in a new Heap Object every single time.
            for (int i = 0; i < iterations; i++)
            {
                arrayList.Add(i);
                //arrayList.Add(10.3);
                //arrayList.Add("Mahesh");
            }

            // UNBOXING happens here!
            // We must cast (int) explicitly to get the value back.
            int value = (int)arrayList[0];


            // -------------------------------------------------
            // 2. THE NEW WAY (List<T>) - FAST & SAFE
            // -------------------------------------------------
            List<int> genericList = new List<int>();

            // NO BOXING.
            // The int 'i' is stored directly as a 32-bit integer.
            for (int i = 0; i < iterations; i++)
            {
                genericList.Add(i);
            }

            // NO UNBOXING.
            // No casting needed. The compiler knows it's an int.
            int value2 = genericList[0];

            string a = value2.ToString();
            int? test = null;

            List<int> listofinteger = new List<int>();
            listofinteger.Add(10);
            listofinteger.Add(10);
            listofinteger.Add(12);
            listofinteger.Remove(10);
            
        }
    }
}
