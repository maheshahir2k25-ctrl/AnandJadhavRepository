using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{

    public class CopyConstructorExample
    {
        public int a; public int b;
        public Example example;
        public CopyConstructorExample()
        {
        }
        //Copy Constructor
        public CopyConstructorExample(CopyConstructorExample obj)
        {
            a = obj.a;
            b = obj.b;

            example = obj.example;//Shallow Copy    

            //Deep Copy
            //example = new Example();
            //example.a = obj.example.a;
            //example.b = obj.example.b;

        }

    }

    public interface MyInterfacee
    {
        int myint { get; set; }


    }

}
