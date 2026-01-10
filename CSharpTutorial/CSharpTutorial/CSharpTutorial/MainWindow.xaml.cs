using CSharpTutorial.DesignPatterns.Behavioral;
using CSharpTutorial.DesignPatterns.Structural;
using CSharpTutorial.DesignPatterns.Structural.Decorator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Value Type vs Reference Type
            //_001_ValueTypevsRefereceType _001_ValueTypevsRefereceType = new _001_ValueTypevsRefereceType();
            //_001_ValueTypevsRefereceType.Execute();

            #endregion

            #region Shallow Copy vs Deep Copy

            //Debug.WriteLine($"==========================Shallow Copy before update===================================================");
            //DeepCopyVsShallowCopy firstObject = new DeepCopyVsShallowCopy();
            //firstObject.ValueType1 = 50;
            //firstObject.ValueType2 = 100;
            //firstObject.ObjectOfExampleClass = new Example();
            //firstObject.ObjectOfExampleClass.a = 10;
            //firstObject.ObjectOfExampleClass.b = 20;
            //Debug.WriteLine($"firstObject.ValueType1 = {firstObject.ValueType1}");
            //Debug.WriteLine($"firstObject.ValueType2 = {firstObject.ValueType2}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.a = {firstObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.b = {firstObject.ObjectOfExampleClass.b}");

            ////DeepCopyVsShallowCopy SecondObject = firstObject; //This will hold the complete referece of first object if any changes made in value type of first object it will be updated in second object too
            ////To overcome from this problem we use Shellow Copy if only Value types are present in class and Deep Copy if there are reference types available.

            //DeepCopyVsShallowCopy SecondObject =  firstObject.ShallowCopy(firstObject);
            //Debug.WriteLine($"SecondObject.ValueType1 = {SecondObject.ValueType1}");
            //Debug.WriteLine($"SecondObject.ValueType2 = {SecondObject.ValueType2}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.a = {SecondObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.b = {SecondObject.ObjectOfExampleClass.b}");

            //Debug.WriteLine($"==========================Shallow Copy After Update===================================================");

            //firstObject.ValueType1 = 111;
            //firstObject.ValueType2 = 222;
            //firstObject.ObjectOfExampleClass.a = 333;
            //firstObject.ObjectOfExampleClass.b = 444;
            //Debug.WriteLine($"firstObject.ValueType1 = {firstObject.ValueType1}");
            //Debug.WriteLine($"firstObject.ValueType2 = {firstObject.ValueType2}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.a = {firstObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.b = {firstObject.ObjectOfExampleClass.b}");

            //Debug.WriteLine($"SecondObject.ValueType1 = {SecondObject.ValueType1}");
            //Debug.WriteLine($"SecondObject.ValueType2 = {SecondObject.ValueType2}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.a = {SecondObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.b = {SecondObject.ObjectOfExampleClass.b}");

            //Debug.WriteLine($"****************************Deep Copy***************************************************");

            //SecondObject = firstObject.DeepCopy(firstObject);
            //Debug.WriteLine($"****************************Deep Copy before update***************************************************");
            //Debug.WriteLine($"firstObject.ValueType1 = {firstObject.ValueType1}");
            //Debug.WriteLine($"firstObject.ValueType2 = {firstObject.ValueType2}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.a = {firstObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.b = {firstObject.ObjectOfExampleClass.b}");

            //Debug.WriteLine($"SecondObject.ValueType1 = {SecondObject.ValueType1}");
            //Debug.WriteLine($"SecondObject.ValueType2 = {SecondObject.ValueType2}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.a = {SecondObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.b = {SecondObject.ObjectOfExampleClass.b}");

            //Debug.WriteLine($"****************************Deep Copy after update***************************************************");
            //firstObject.ValueType1 = 999;
            //firstObject.ValueType2 = 888;
            //firstObject.ObjectOfExampleClass.a = 777;
            //firstObject.ObjectOfExampleClass.b = 666;
            //Debug.WriteLine($"firstObject.ValueType1 = {firstObject.ValueType1}");
            //Debug.WriteLine($"firstObject.ValueType2 = {firstObject.ValueType2}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.a = {firstObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"firstObject.ObjectOfExampleClass.b = {firstObject.ObjectOfExampleClass.b}");

            //Debug.WriteLine($"SecondObject.ValueType1 = {SecondObject.ValueType1}");
            //Debug.WriteLine($"SecondObject.ValueType2 = {SecondObject.ValueType2}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.a = {SecondObject.ObjectOfExampleClass.a}");
            //Debug.WriteLine($"SecondObject.ObjectOfExampleClass.b = {SecondObject.ObjectOfExampleClass.b}");
            #endregion

            #region Copy Constructor

            //Debug.WriteLine($"==========================Copy Constructor before update===================================================");
            //CopyConstructorExample copyConstructorexample = new CopyConstructorExample();
            //copyConstructorexample.a = 10;
            //copyConstructorexample.b = 20;
            //copyConstructorexample.example = new Example();
            //copyConstructorexample.example.a = 30;
            //copyConstructorexample.example.b = 40;

            //CopyConstructorExample copyConstructorexample2 = new CopyConstructorExample(copyConstructorexample);//Calling Copy Constructor

            //Debug.WriteLine($"copyConstructorexample.a = {copyConstructorexample.a}");
            //Debug.WriteLine($"copyConstructorexample.b = {copyConstructorexample.b}");
            //Debug.WriteLine($"copyConstructorexample.example.a = {copyConstructorexample.example.a}");
            //Debug.WriteLine($"copyConstructorexample.example.b = {copyConstructorexample.example.b}");
            //Debug.WriteLine($"-------------------------------------------------------------------------");
            //Debug.WriteLine($"copyConstructorexample2.a = {copyConstructorexample2.a}");
            //Debug.WriteLine($"copyConstructorexample2.b = {copyConstructorexample2.b}");
            //Debug.WriteLine($"copyConstructorexample2.example.a = {copyConstructorexample2.example.a}");
            //Debug.WriteLine($"copyConstructorexample2.example.b = {copyConstructorexample2.example.b}");

            //Debug.WriteLine($"==========================Copy Constructor after update===================================================");
            //copyConstructorexample.a = 111;
            //copyConstructorexample.b = 222;
            ////copyConstructorexample.example = new Example();
            //copyConstructorexample.example.a = 333;
            //copyConstructorexample.example.b = 444;

            //Debug.WriteLine($"copyConstructorexample.a = {copyConstructorexample.a}");
            //Debug.WriteLine($"copyConstructorexample.b = {copyConstructorexample.b}");
            //Debug.WriteLine($"copyConstructorexample.example.a = {copyConstructorexample.example.a}");
            //Debug.WriteLine($"copyConstructorexample.example.b = {copyConstructorexample.example.b}");
            //Debug.WriteLine($"-------------------------------------------------------------------------");
            //Debug.WriteLine($"copyConstructorexample2.a = {copyConstructorexample2.a}");
            //Debug.WriteLine($"copyConstructorexample2.b = {copyConstructorexample2.b}");
            //Debug.WriteLine($"copyConstructorexample2.example.a = {copyConstructorexample2.example.a}");
            //Debug.WriteLine($"copyConstructorexample2.example.b = {copyConstructorexample2.example.b}");

            #endregion

            #region AsyncAwait  



            #endregion

            #region Inheritance

            //GoogleMusic gmusic = new GoogleMusic();
            //gmusic.Play();

            //AppleMusic appleMusic = new GoogleMusic();
            //appleMusic.Play();

            //SamsungMusic samsungMusic = new AppleMusic();
            //samsungMusic.Play();
            #endregion

            #region DiamondProblem

            //MainClass mainClass = new MainClass();
            //mainClass.Execute();


            #endregion

            #region Anonymous Object
            //AnonymousObject anonymousObject = new AnonymousObject();
            //anonymousObject.MyMethod();

            #endregion

            #region ExtensionMethods
            //ExtensionMethodExample extensionMethodExample = new ExtensionMethodExample();
            //extensionMethodExample.Execute();
            #endregion

            #region TryCatchFinally
            //TryCatchFinally tryCatchFinally = new TryCatchFinally();
            //bool result = tryCatchFinally.Execute();
            //tryCatchFinally.ReadUserAge();
            #endregion

            #region CustomExceptions

            //try
            //{
            //    ExceptionTest exceptionTest = new ExceptionTest();
            //    exceptionTest.RegisterUser(15);
            //}
            //catch (CustomExceptions ex) when (ex.ErrorCode == 101 || ex.CanRetry ==true)//Filters in Custom Exception
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    ExceptionTest exceptionTest = new ExceptionTest();
            //    exceptionTest.RegisterUser(18);
            //    Console.WriteLine("Registration Successfull !!");
            //}
            //catch (CustomExceptions ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion


            #region Exception Filters
            //ExceptionFilters exceptionFilters=  new ExceptionFilters();
            //exceptionFilters.ExceptionFilterTestMehod();

            #endregion


            #region MultiCastDelegate

            //TestDelegateUser testDelegateUser = new TestDelegateUser();


            #endregion

            #region Events 
            //EventsTest eventsTest = new EventsTest();
            //eventsTest.Execute();
            #endregion


            #region Linq
            //LinqExample linqExample = new LinqExample();
            //linqExample.Execute();

            #endregion

            #region Dependency Injection (Inversion of Control)

            //NotificationService notificationService = new NotificationService(new SMSSender(), "Welcome to our service!");
            //notificationService.SendNotification("Hello this is MyNotification");

            //notificationService = new NotificationService(new EmailSender(), "Welcome to our service!");
            //notificationService.SendNotification("This is Email");

            //notificationService = new NotificationService(new InstagramSender(), "Welcome to our Instagram!");
            //notificationService.SendNotification("This is Email");

            #endregion

            #region Decorator Pattern
            //Decorator2Test decoretorTest = new Decorator2Test();
            //decoretorTest.Main();

            #endregion


            #region Strategy Pattern

            StrategyTest strategyTest = new StrategyTest();
            strategyTest.Main();
            #endregion

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //AsyncAwaitTask asyncAwaitTask = new AsyncAwaitTask();
            //asyncAwaitTask.LongRunningOperation();

            //this.LongRunningOperation();

            AsyncAwaitTask asyncAwaitTask = new AsyncAwaitTask();
            await asyncAwaitTask.ExecuteUsingAsync();
        }

        public void LongRunningOperation()
        {
            //int i = 0;
            //for (; i <= 10000;)
            //{
            //    this.Title = i++.ToString();
            //    //await Task.Delay(1); //I/O bound Operation
            //}

            //CPU Bound Operation
            Task.Run(() =>
            {
                int j = 0;
                for (; j <= 10000;)
                {
                    UpdateUI(j++);
                    //this.Title = j++.ToString();//This will give error as we are trying to update UI element from non UI thread
                }
            });


        }

        public void UpdateUI(int j)
        {
            if (!CheckAccess())
            {
                // On a different thread
                Dispatcher.Invoke(() => UpdateUI(j));
                return;
            }
            this.Title = j.ToString();
        }

    }
}
