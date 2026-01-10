using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CSharpTutorial
{
    //Key Topics to Study:
    //The "Big Three": Where(Filter), Select(Map/Transform), First/FirstOrDefault.
    //Deferred Execution(Lazy Evaluation): The most asked interview question in LINQ.
    //Method Syntax vs Query Syntax: Fluent API(.Where().Select()) vs SQL-style(from x in list...).
    //IQueryable vs IEnumerable: The difference between in-memory filtering and database-side filtering.

    public class LinqUser
    {
        public int Id;
        public string Name;
        public int Age;
    }

    public class LinqExample
    {
        public void Execute()
        {
            List<LinqUser> users = new List<LinqUser>
            {
                new LinqUser { Id = 1, Name = "Alice", Age = 30 },
                new LinqUser { Id = 2, Name = "Bob", Age = 25 },
                new LinqUser { Id = 3, Name = "Charlie", Age = 35 },
                new LinqUser { Id = 4, Name = "Diana", Age = 28 }
            };

            // 1. WHERE: Filter users age less than 30
            IEnumerable<LinqUser> UsersList2 = users.Where(x => x.Age < 30).ToList();// Immediate Execution
            IEnumerable<LinqUser> UsersList = users.Where(x => x.Age < 30);          // Deffered Execution Lazy loading (the list will populate on foreach loop)

            //Returns IEnumerable<T> / IQueryable<T> (Where, Select, Take) $\rightarrow$ Deferred.
            //Returns a concrete result (ToList, Count, First, Sum) $\rightarrow$ Immediate.

            users.Add(new LinqUser { Id = 4, Name = "Anand", Age = 24 });

            IEnumerable names = users.Select(u => u.Name);
            // Result: "Alice", "Charlie"

            IEnumerable namesWithwhereAndSelect = users.Where(x => x.Age < 30) //Method Syntax
                                                       .Select(x => x.Name);



            Console.WriteLine("-------Where Output---------");

            foreach (var User in UsersList)
            {
                Console.WriteLine(User.Name);
            }

            Console.WriteLine("-------Select Output---------");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("-------Where and Select Output---------");

            foreach (var name in namesWithwhereAndSelect)
            {
                Console.WriteLine(name);
            }

            //Query Syntax
            var queryResult = from n in users
                              where n.Age < 30
                              orderby n.Name descending
                              select n.Name;

            Console.WriteLine("-----------------Query Syntax Result-------------------------");
            foreach (var userName in queryResult)
            {
                Console.WriteLine(userName);

            }

            ///////////////Linq Join Example/////////////////////

            List<Student> students = new List<Student>
            {
                new Student { Name = "Diana", ClassId = 3 },
                new Student { Name = "Charlie", ClassId = 1 },
                new Student { Name = "Alice", ClassId = 1 },
                new Student { Name = "Bob", ClassId = 2 }


            };
            List<Class> classes = new List<Class>
            {
                new Class { Id = 1, ClassName = "Math" },
                new Class { Id = 2, ClassName = "Science" },
                new Class { Id = 3, ClassName = "History" }
            };


            var StudentWithClass = from s in students
                                   join C in classes on s.ClassId equals C.Id
                                   orderby s.Name ascending
                                   select new { s.Name, C.ClassName };

            Console.WriteLine("-----------------Query Syntax Join Example-------------------------");
            foreach (var studentClass in StudentWithClass)
            {
                Console.WriteLine(studentClass);

            }

            // Collection.Join(target, OuterKey, InnerKey, ResultSelector)
            var methodResult = students.Join(
                classes,                  // 1. Target List
                s => s.ClassId,           // 2. Key from Students
                c => c.Id,                // 3. Key from Classes
                (s, c) => new { s.Name, c.ClassName } // 4. Result Selector (The Join Logic)
            ).OrderBy(c => c.Name);
            Console.WriteLine("-----------------Method Syntax Join Example-------------------------");
            foreach (var StdClass in methodResult)
            {
                Console.WriteLine(StdClass);

            }

            ////First vs FirstOrDefault
            var studentsWithClassId4 = students.Where(s => s.ClassId == 3).First(); //It will crash if element not present in collection 
            studentsWithClassId4 = students.Where(s => s.ClassId == 4).FirstOrDefault(); //It will not crash and return null


            List<string> namesList = new List<string>() { "Mahesh", "Anand" };

            //Where will change the number of items
            var filterList = namesList.Where(n => n == "Anand").ToList();

            //Select will change the type/shape of items
            filterList = namesList.Select(n => n.ToLower()).ToList();


        }
    }


    public class Student
    {
        public string Name { get; set; }
        public int ClassId { get; set; }

    }
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

    }
}
