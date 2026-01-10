using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTutorial
{
    public class VideoChannel //Notification Event Publisher
    {
        // 1. Define the Event (based on an Action or Delegate)
        // "OnVideoUploaded" is the name. It passes a string (video title).
        public event Action<string> OnVideoUploaded;
        public bool IsSuccessful { get; set; }
        public void UploadVideo(string title)
        {
            Console.WriteLine($"Uploading '{title}'...");
            Thread.Sleep(1000); // Simulate work

            // 2. Raise the Event (Notify Subscribers)
            // Check if anyone is listening (Not Null)
            if (OnVideoUploaded != null)
            {
                OnVideoUploaded(title);
            }
            IsSuccessful = true;
        }
    }

    public class VideoUser
    {
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }

        public void OnNotificationReceived(string title)
        {
            Console.WriteLine($"[User {Name}]: Wow! New video '{title}' is out!");
        }
        
    }

    public class EventsTest //Subscriber
    {
        List<VideoUser> userList;
        public void Execute()
        {
            var channel = new VideoChannel();
            var user1 = new VideoUser { Name = "Mahesh",IsSubscribed=true };
            var user2 = new VideoUser { Name = "Anand", IsSubscribed = true };
            List<VideoUser> userList=new List<VideoUser> { user1 ,user2};
            // 3. Subscription (Using +=)
            // We are NOT calling the method here. We are attaching it.
            if(user1.IsSubscribed)
                channel.OnVideoUploaded += user1.OnNotificationReceived; //Subscribe Event for user1
            if (user2.IsSubscribed)
                channel.OnVideoUploaded += user2.OnNotificationReceived; //Subscribe Event for user2

            // Action: Channel uploads. Both users get notified automatically.
            channel.UploadVideo("C# Tutorial");
            
            // 4. Unsubscription (Using -=)
            Console.WriteLine("\n-- Alice Unsubscribes --");
            channel.OnVideoUploaded -= user1.OnNotificationReceived;//Unsubscribe Event for user1

            channel.UploadVideo("Advanced Events");
            // Result: Only Bob gets the notification now.

        }

       

    }
}