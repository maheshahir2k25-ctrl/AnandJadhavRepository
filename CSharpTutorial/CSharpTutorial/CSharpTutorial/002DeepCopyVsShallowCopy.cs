using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    /// <summary>
    /// Definition
    /// Shallow Copy copies values types and reference type both but holds the referece of reference types. We can perform ShallowCopy using MemberwiseClone() method.
    /// In Deep Copy we perform memberrWiseClone() as well as create new instance for reference types and assign default value to them.
    /// </summary>
    public class Example
    {
        public int a; public int b;
        public Example()
        {

        }
    }
    public class DeepCopyVsShallowCopy
    {

        public int ValueType1 = 10; //Value Type
        public int ValueType2 = 20;//Value Type
        public Example ObjectOfExampleClass;//Reference Type

        public DeepCopyVsShallowCopy DeepCopy(DeepCopyVsShallowCopy obj)
        {
            DeepCopyVsShallowCopy obj1 = (DeepCopyVsShallowCopy)obj.MemberwiseClone();
            obj1.ObjectOfExampleClass = new Example();
            obj1.ObjectOfExampleClass.a = 0;
            obj1.ObjectOfExampleClass.b = 0;
            return obj1;
        }
        public DeepCopyVsShallowCopy ShallowCopy(DeepCopyVsShallowCopy obj)
        {
            DeepCopyVsShallowCopy obj1 = (DeepCopyVsShallowCopy)obj.MemberwiseClone();
            return obj1;
        }



    }
}
