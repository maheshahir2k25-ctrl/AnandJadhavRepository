using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public class ExceptionFilters
    {

        public void SQLEception() 
        {
            try
            {
                // Code that might fail
            }
            catch (SqlException ex) when (ex.Number == 1205) // 1205 = Deadlock
            {
                // Only runs if it's a SQL Deadlock. 
                // If it's a syntax error (different number), this block is skipped.
                RetryTransaction();
            }
            catch (SqlException ex)
            {
                // Handle all other SQL errors
                LogError(ex);
            }

        }

        //Scenario A: Handling Web Requests (404 vs 500)
        public async void APIHTTPException()
        {
            //try
            //{
            //    // Code to call an API
            //    await CallMyApiAsync();
            //}
            //// Filter 1: Handle "Not Found" specifically
            //catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    Console.WriteLine("Page not found. Show empty state.");
            //}
            //// Filter 2: Handle Server Errors (500)
            //catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    Console.WriteLine("Server is down. Retry later.");
            //}
            //// Catch all other HTTP errors
            //catch (HttpRequestException ex)
            //{
            //    Console.WriteLine($"Unknown API error: {ex.Message}");
            //}
            

        }
        //Scenario B: Filtering based on Message (Legacy Code)
        //Sometimes you use a library that throws a generic Exception but changes the text message.Ideally, you shouldn't rely on strings, but sometimes you have to.

        private void Mymethhod()
        {
            try
            {
                ProcessData();
            }
            // Only catch if the text says "Timeout". Let "Database Error" crash the app.
            catch (Exception ex) when (ex.Message.Contains("Timeout"))
            {
                Console.WriteLine("The operation took too long, retrying...");
                Retry();
            }
        }
        private void ProcessData() { }
        private void Retry() { }
        private void LogError(SqlException ex)
        {
            
        }

        public void RetryTransaction()
        { 
        
        }
        private async Task CallMyApiAsync()
        { 
        
        
        }

        public void DangerousMethod()
        {
            try
            {
                // Code that crashes
                throw new InvalidOperationException("Boom");
            }
            // usage of a helper method in the filter
            catch (Exception ex) when (LogOnly(ex))
            {
                // This block is UNREACHABLE because LogOnly returns false.
            }
        }

        // Helper method
        private bool LogOnly(Exception ex)
        {
            Console.WriteLine($"Logging Error: {ex.Message}");
            return true; // Tells the catch block: "Don't catch this, keep searching!"
        }


        public void ExceptionFilterTestMehod()
        {
            this.DangerousMethod();
            //try
            //{
            //    this.DangerousMethod();
            //}
            //catch (Exception ex)
            //{ 
            //}
        }


    }
}
