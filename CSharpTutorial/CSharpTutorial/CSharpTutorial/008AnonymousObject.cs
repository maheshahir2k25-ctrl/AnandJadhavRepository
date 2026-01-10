using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public class AnonymousObject
    {
        public void MyMethod()
        {
            // ✅ Creates a temporary object with 'Name' and 'Age' properties
            var person = new { Name = "John", Age = 30 };
            
            Debug.WriteLine(person.Name);
        }
    }
}
