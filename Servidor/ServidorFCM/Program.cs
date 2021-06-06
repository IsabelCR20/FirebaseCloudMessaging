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
                //Storage = StorageClient.Create(credential)
                //Credential = GoogleCredential.GetApplicationDefault(),
            });

            //autenticar con un token de actualización de Google OAuth2
            /*
            FirebaseApp.Create(new AppOptions(){
                Credential = GoogleCredential.FromFile("path/to/refreshToken.json"),
            });*/

            // This registration token comes from the client FCM SDKs.
            //Task t = EnviarMsj();
            //t.Wait();
            Task t = EnviarNotificacion();
            t.Wait();

        }

        static async Task EnviarMsj()
        {
            var registrationToken = "dnvCJQ9CQA-owE-W19PH1h:APA91bEcKTScvzPXoBqFcJihNHGwNpwzpoyhaSxzV6GYYmTcSEdAWoJ-tL_wCjUE9_K_xQp8tUcfq4fqxF4rAv51WolNKgAHH_6D4aNZTWrxZPRiE2vlUv1do3-Ney3uXUoQQ38YOnbo";

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
            var registrationToken = "eR7w091tRMaVGVUaxmx3qB:APA91bEZWd95tS7hOGuEdX3FcryNq7UN_z1IZHTl46owFrYZB-vOtIcFaykAh-Tj9v9EA3qGEsSiYdz1V26mZKdSd6Dbq5ulnl6ynyERs7649Xce-sEaN28QAGg9STrRO6tXdaxVy0Dd";
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
