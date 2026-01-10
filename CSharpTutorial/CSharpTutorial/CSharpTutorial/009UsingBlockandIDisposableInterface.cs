using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSharpTutorial
{
    public class UsingBlock : IDisposable
    {
        FileStream m;
        // IntPtr is a "Pointer" or "Handle". 
        // It holds the memory address (e.g., 0x00A1B2) of the unmanaged memory.
        private IntPtr _unmanagedPointer;
        SafeHandle handle;
        bool isDisposed = false;
        List<string> classes;
        ~UsingBlock()   // Destructor
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            // Tell the GC: "I cleaned this up myself, don't run the Finalizer."
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                // cleanup Managed Resources
                foreach (var item in classes)
                {
                    classes = null;
                }
                classes = null;
            }

            //Cleanup Unmanged Resource
            _unmanagedPointer = IntPtr.Zero;
            handle = null;

            isDisposed = true;
        }

        public void UnmanagedMemoryHolder(int size)
        {

            Console.WriteLine($"Allocating {size} bytes of unmanaged memory...");

            // Marshal.AllocHGlobal asks the OS directly for memory.
            // The Garbage Collector DOES NOT know this memory exists.
            // If you lose this pointer, that RAM is gone until you reboot the app/computer.
            _unmanagedPointer = Marshal.AllocHGlobal(size);
        }

    }

    public class MainClass1: UsingBlock, IDisposable
    {
        private bool IsDisposed = false;

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
            { 
            //cleanup Mangaged resources
            }
            //Cleanup Unmanaged Resources

            base.Dispose(true);
        }
        ~MainClass1() 
        {
            this.Dispose(false);//Will call Parent Dispose() method if collected by GC
        }


        public void Execute()
        {
            //it will cleaned up by garbage collector
            UsingBlock usingBlock = new UsingBlock();
            usingBlock.UnmanagedMemoryHolder(10);
            usingBlock.Dispose();
            //
            using (UsingBlock c = new UsingBlock())
            {
                c.UnmanagedMemoryHolder(100);
                
            }

        }

    }

    //We don't have GC.SuppressFinalize(this); line in child class. Why ?
//The reason we do not have GC.SuppressFinalize(this); in the Child class is simple: The Child class inherits the Public Dispose() method from the Base class.

//You do not need to write it again because the code in the Base class handles it for the entire object (including the Child part).

//How it works(The Execution Flow)
//When you create an instance of the Child class and call Dispose:

//C#

//MainClass1 child = new MainClass1();
//    child.Dispose(); 
//Here is exactly what happens step-by-step:

//Compiler Look-up: The compiler looks for Dispose() in MainClass1.It doesn't find a public Dispose() there (because we deleted the incorrect one).

//Inheritance: The compiler goes up to the parent, UsingBlock, and finds public void Dispose().

//Execution: It runs the Base Class's public method:

//C#

//// Inside UsingBlock (Base)
//public void Dispose()
//    {
//        Dispose(true); // Calls Virtual Method (Polymorphism sends this to Child!)

//        GC.SuppressFinalize(this); // <--- THIS RUNS FOR THE CHILD
//    }
//    The this Keyword: Even though this code is written in the Base class, this refers to the runtime object. In this case, this IS the MainClass1 instance.


//    Result: The entire object (Child + Base) is removed from the Finalization queue.

//Why adding it to the Child is wrong
//    If you try to add GC.SuppressFinalize(this) in the Child class, you would have to create a public Dispose() method in the Child to put it in.

//As we discussed, creating a public Dispose() in the Child hides the Base method and breaks the pattern.By relying on inheritance, you write the cleanup logic (SuppressFinalize) once in the Base, and it works for every single class that ever inherits from it.

//Summary
//Base Class: Defines the "Template" (Public API + SuppressFinalize).

//Child Class: Only provides the "Ingredients" (Overrides the protected Dispose(bool) logic).

}
