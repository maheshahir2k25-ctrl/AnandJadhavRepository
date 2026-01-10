using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpTutorial
{

    //    The Hierarchy(Visualizing the Family Tree)
    //Think of it like a job promotion ladder.
    //IEnumerable<T>(The Intern): Can only look at one file at a time.Cannot change anything.
    //ICollection<T>(The Junior): Can count the files and add/remove files.
    //IList<T>(The Manager): Can do everything the others can, PLUS jump to any specific file instantly(Random Access).
    //1. IEnumerable<T>(The "ReadOnly Stream")
    //Definition: "I can give you the Next item."
    //Superpower: Lazy Loading.It pulls data one by one.This is crucial for databases (Entity Framework) because you don't want to load 1 million rows into RAM just to count them.
    //Limitations:
    //You cannot count it instantly (you must loop to count).
    //You cannot access index[5] (you must step 0, 1, 2, 3, 4, 5).
    //You cannot add or remove items.
    //2. IList<T> (The "Random Access Editor")
    //Definition: "I control the entire list in memory."
    //Superpower: Random Access.It knows exactly where item [100] is in memory.
    //Limitations: It forces the entire collection to be loaded into memory (RAM). You cannot have an "infinite" IList.

//    Feature,     IEnumerable<T>,      ICollection<T>,           IList<T>
//Loop(foreach),    ✅ Yes,                ✅ Yes,                  ✅ Yes
//Count,            ❌ No(Must Loop),      ✅ Yes(.Count),          ✅ Yes
//Add/Remove,       ❌ No,                 ✅ Yes,                  ✅ Yes
//Check Existence,  ❌ No,                 ✅ Yes(.Contains),       ✅ Yes
//Index Access([i]),❌ No,                 ❌ No,                   ✅ Yes
//Primary Use,      Reading Data,       Modifying Data(No Order),   Modifying Data(With Order)


    public class HierarchyDemo
    {
        public void RunDemo()
        {
            // A standard List implements both IEnumerable and IList
            List<string> employees = new List<string> { "Alice", "Bob", "Charlie", "Dave" };

            Console.WriteLine("--- SCENARIO 1: The Viewer (IEnumerable) ---");
            // We pass the list to a method that simply needs to READ data.
            PrintNames(employees);

            Console.WriteLine("\n--- SCENARIO 2: The Editor (IList) ---");
            // We pass the list to a method that needs to MODIFY data.
            ManageTeam(employees);

            // List implements ICollection, so we can pass it in.
            List<string> bag = new List<string> { "Apple", "Banana" };

            ModifyBag(bag);
        }

        // ---------------------------------------------------------
        // 1. IEnumerable: The "ReadOnly Iterator"
        // Use this when you just want to loop through data.
        // ---------------------------------------------------------
        public void PrintNames(IEnumerable<string> staff)
        {
            // ✅ ALLOWED: Foreach loop (The only thing you can really do)
            foreach (var person in staff)
            {
                Console.WriteLine($"Found: {person}");
            }

            // ❌ ERROR: Cannot use Indexer
            // Console.WriteLine(staff[0]); 

            // ❌ ERROR: Cannot Add/Remove
            // staff.Add("Eve"); 

            // ❌ ERROR: No .Count property (You must use LINQ .Count() which loops)
            // int c = staff.Count; 
        }
        // ---------------------------------------------------------
        // 2. ICollection: 
        // ---------------------------------------------------------
        public void ModifyBag(ICollection<string> items)
        {
            // ✅ 1. IT KNOWS THE COUNT (Unlike IEnumerable)
            Console.WriteLine($"Total Items: {items.Count}");

            // ✅ 2. IT CAN MODIFY (Add/Remove/Clear)
            items.Add("Cherry");
            items.Remove("Apple");

            // ✅ 3. IT CAN CHECK EXISTENCE
            bool hasBanana = items.Contains("Banana");

            // ✅ 4. IT CAN LOOP (Inherits IEnumerable)
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            // ❌ ERROR: NO RANDOM ACCESS (Indexer)
            // You cannot ask for the "first" or "second" item by index.
            // Console.WriteLine(items[1]); // Compile Error!
        }


        // ---------------------------------------------------------
        // 3. IList: The "Random Access Editor"
        // Use this when you need Indexing, Adding, Removing, or Counting.
        // ---------------------------------------------------------
        public void ManageTeam(IList<string> staff)
        {
            // ✅ ALLOWED: Random Access by Index (Fast O(1))
            Console.WriteLine($"The second employee is: {staff[1]}");

            // ✅ ALLOWED: Modification (Add/Remove)
            staff.Add("Eve");
            staff.RemoveAt(0); // Fire Alice

            // ✅ ALLOWED: Instant Count
            Console.WriteLine($"Total Staff: {staff.Count}");

            // ✅ ALLOWED: You can still loop because IList inherits IEnumerable
            foreach (var person in staff)
            {
                Console.WriteLine(person);
            }
        }
    }
}
