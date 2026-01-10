using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Data.Entity;

namespace CSharpTutorial
{
// The Core Difference: "Where does the filtering happen?"
//1. IEnumerable(Client-Side Evaluation)
//Behavior: It fetches ALL data from the database into your application's memory (RAM) first.
//Filtering: Then, C# filters it inside your computer's CPU.
//Metaphor: You ask the waiter for "The menu." He brings every single dish from the kitchen to your table.You then pick the one you want and throw the rest in the trash.
//Performance: Terrible for large datasets.
//2. IQueryable (Server-Side Evaluation)
//Behavior: It builds a "Expression Tree" (a plan). It does not fetch data yet.
//Filtering: When you run it, it translates your C# .Where() into a real SQL WHERE clause. It sends that SQL to the database. The Database filters it and sends back only the matching rows.
//Metaphor: You tell the waiter "I want the Steak." He goes to the kitchen and brings back only the Steak.
//Performance: Excellent.
    public class IEnumerableVsIQuerable
    {
        public void IEnumerableVsIQuerableExample()
        {
            // DATABASE CONTEXT (Entity Framework)
            AppDbContext db = new AppDbContext();

            // ---------------------------------------------------------
            // SCENARIO A: IEnumerable (The Mistake)
            // ---------------------------------------------------------
            // 1. AsEnumerable() cuts the link to SQL translation.
            IEnumerable<DbUser> query = db.Users.AsEnumerable();

            // 2. The Filter
            // BAD: This fetches ALL 1,000,000 rows into RAM first!
            // Then C# loops through 1,000,000 objects to find Alice.
            var user = query.Where(u => u.Name == "Alice").ToList();


            // ---------------------------------------------------------
            // SCENARIO B: IQueryable (The Professional Way)
            // ---------------------------------------------------------
            // 1. AsQueryable() keeps the link alive.
            IQueryable<DbUser> query2 = db.Users.AsQueryable();

            // 2. The Filter
            // GOOD: This translates to SQL: "SELECT * FROM Users WHERE Name = 'Alice'"
            // The Database sends back ONLY 1 row. Your RAM is happy.
            var user2 = query.Where(u => u.Name == "Alice").ToList();
        }
        
    }

    // 1. The Model (Represents a Table in your database)
    public class DbUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // 2. The Context (Represents the Database)
    // You must create this class and inherit from 'DbContext'
    public class AppDbContext : DbContext
    {
        // This constructor tells EF where the database is.
        // If you don't have a specific connection string yet, 
        // it will create a LocalDB automatically named "MyDatabase".
        public AppDbContext() : base("name=MyDatabase")
        {
        }

        // This property creates a "Users" table in the database
        public DbSet<DbUser> Users { get; set; }
    }

}
