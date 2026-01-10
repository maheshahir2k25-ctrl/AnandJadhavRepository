using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public class _001_ValueTypevsRefereceType
    {

        struct Mystruct
        {
            public int x;
            public int y;
            Mystruct(int a, int b)
            {
                x = a;
                y = b;
            }
        }

        class Myclass
        {
            public int x;
            public int y;
            public Myclass(int a, int b)
            {
                x = a;
                y = b;
            }
        }

        public void Execute()
        {
            Mystruct s1 = new Mystruct();
            s1.x = 10;
            s1.y = 20;
            Mystruct s2 = s1; // Copying the value
            s2.x = 30;
            Debug.WriteLine("Structs:");
            Debug.WriteLine("s1.x: " + s1.x); // Outputs 10
            Debug.WriteLine("s2.x: " + s2.x); // Outputs 30
            Myclass c1 = new Myclass(10, 20);
            Myclass c2 = c1; // Copying the reference
            c2.x = 30;
            Debug.WriteLine("Classes:");
            Debug.WriteLine("c1.x: " + c1.x); // Outputs 30
            Debug.WriteLine("c2.x: " + c2.x); // Outputs 30
        }

    }
}
