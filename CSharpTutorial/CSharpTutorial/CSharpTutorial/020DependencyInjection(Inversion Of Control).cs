using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial
{

    public interface INotificationSender
    {
        void Send( string message);
    }

    public class EmailSender: INotificationSender
    {
        public void Send(string message)
        {
           
        }
       
    }
    public class InstagramSender : INotificationSender
    {
        public void Send(string message)
        {

        }
      
    }


    public class SMSSender: INotificationSender
    {
        public void Send( string message)
        {
            
        }

        
    }

    public class NotificationService
    {
        INotificationSender NotificationSender;
        string message;

        public NotificationService(INotificationSender notificationSender, string Message)
        {
            NotificationSender = notificationSender;
            message = Message;
        }
        public void SendNotification(string recipient)
        {
            NotificationSender.Send(this.message);
        }


    }















    public class DependencyInjectionExample
    {
        
    }

}
