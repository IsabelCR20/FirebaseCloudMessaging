using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace ServidorFCM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Inicialización del SDK
            FirebaseApp.Create(new AppOptions() {
                Credential = GoogleCredential.FromFile("C:/Users/Lenovo T540P/OneDrive/Documentos/ITSUR/VIII Semestre/MOVIL II - 2/U6/Firebase/Servidor/fcmessaging-18e6c-firebase-adminsdk-wgy3l-efdb41a902.json")
            });
            Task t = EnviarNotificacion();
            t.Wait();

        }

        static async Task EnviarMsj()
        {
            var registrationToken = "MI TOKEN";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "score", "120" },
                    { "time", "3:45" },
                },
                Token = registrationToken,
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }

        static async Task EnviarNotificacion(){
            var registrationToken = "MI TOKEN";
            var message = new Message{
                Notification = new Notification()
                {
                    Title = "Canción recomendada del día",
                    Body = "The Weeknd - Save Your Tears",
                },
                Android = new AndroidConfig()
                {
                    TimeToLive = TimeSpan.FromHours(1),
                    Notification = new AndroidNotification()
                    {
                        Icon = "stock_ticker_update",
                        Color = "#BD1258",
                    },
                },
                Token = registrationToken,
            };
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }


    }
}
