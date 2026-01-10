using CSharpTutorial.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSharpTutorial.DesignPatterns
{
//    THE SINGLETON PATTERN
// CATEGORY: CREATIONAL
//1. The Concept
//Imagine a country.A country can have only one President(or Prime Minister) at a time.If you need to sign a law, you go to The President.You don't create a new President every time a law needs signing. You use the existing one.
//The Rule: Ensure a class has only one instance and provide a global point of access to it.
//2. The Problem in Code
//Normally, every time you use the keyword new, you create a fresh object:
//// This creates two completely different people
//Database db1 = new Database();
//    Database db2 = new Database();
//    Sometimes, you want db1 and db2 to actually point to the exact same object (like a shared configuration manager or a database connection pool).
//3. The Solution(C# Example)
//To force only one instance, we do two things:
//Make the Constructor Private (so no one can use new from the outside).
//Create a Public Static Method that returns the single instance.

//Here is the simplest implementation:

public class Logger
    {
        public static Logger _instance;
        private Logger()
        {
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        public void WriteLog(string Message)
        {
            Console.WriteLine($"Log Entry {Message}");
        }
    }

    public class SingletonUser
    {
        public void Execute()
        {
            //Logger logger = new Logger();//Error
            Logger log1 = Logger.GetInstance();
            log1.WriteLog("First Message");
            Logger log2 = Logger.GetInstance();
            log2.WriteLog("Second Message");

            // Proof they are the same object:
            if (log1 == log2)
            {
                Console.WriteLine("Both variables hold the exact same object.");
            }
        }
}

//When to use this?
//CONFIGURATION SETTINGS: You read settings from a file once; you don't want to re-read the file every time you need a setting.

//LOGGING: You want all parts of your app to write to the same log file without opening/closing it constantly.


//-- Thread Safe Version (using lock)
public class ThreadSafeLogger
    {
        public static ThreadSafeLogger _instance;
        public static readonly object _lock = new object();
        private ThreadSafeLogger()
        {

        }
        public ThreadSafeLogger GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new ThreadSafeLogger();
                return _instance;
            }
        }
    }

    //The "Lazy" Version (Best Practice for Modern C#)

    public  class LazySingletonLogger
    {
        private static readonly Lazy<LazySingletonLogger> _lazyInstance = new Lazy<LazySingletonLogger>(() => new LazySingletonLogger());
        private LazySingletonLogger()
        {

        }
        public static LazySingletonLogger Instance
        {

            get { return _lazyInstance.Value; }
        }
    }
}
