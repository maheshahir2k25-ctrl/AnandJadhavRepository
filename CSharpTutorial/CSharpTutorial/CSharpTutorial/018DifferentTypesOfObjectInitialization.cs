using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public class TestUser
    {
        public int Id;
        public string Name;
        public int Age;
        public TestUser() { }
        public TestUser(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
    public class DifferentTypesOfObjectInitialization
    {


        public void CreateObjects()
        {

            //3 types of Object Initialization in C#
            TestUser testUser = new TestUser();
            testUser.Id = 1;
            testUser.Name = "Alice";
            testUser.Age = 30;

            TestUser testUser2 = new TestUser // Object Initializer Syntax //Inline Initialization  
            {
                Id = 2,
                Name = "Bob",
                Age = 25
            };

            TestUser testUser3 = new TestUser(id: 1, name: "Anand", age: 20);//It will call parameterized constructor
            //

            var anonUser = new //Anonymous Type Initialization
            {
                Id = 4,
                Name = "David",
                Age = 35
            };

            //List Initialization with Object Initializer Syntax
            List<TestUser> userList = new List<TestUser>();
            userList.Add(new TestUser { Id = 1, Name = "Alice", Age = 30 }); //Object Initializer Syntax
            userList.Add(testUser);
            userList.Add(testUser2);
            userList.Add(testUser3);    

            List<TestUser> users = new List<TestUser>()
            {
            new TestUser { Id = 1, Name = "Alice", Age = 30 }, //Object Initializer Syntax
            new TestUser { Id = 2, Name = "Anand", Age = 30 }, //Object Initializer Syntax
            new TestUser { Id = 3, Name = "Mahesh", Age = 30 }, //Object Initializer Syntax
            }; 
        }



    }
}
