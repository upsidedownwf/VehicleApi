using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApiData.Interfaces;
using VehicleApiData.HelperModel;
using MimeKit;
using MailKit.Net.Smtp;
using System.Linq;

namespace VehicleApiServices.Services
{
    public class eeee
    {
        private static Duplicator Hook;
        static void Main(string[] args)
        {
            Hook += DuplicatorImpl1;
            Hook += DuplicatorImpl2;
            foreach (Duplicator hook in Hook.GetInvocationList())
            {
                Console.WriteLine(hook.Invoke(2));
            }
            Console.Read();
        }
        static int DuplicatorImpl1(int number)
        {
            Console.WriteLine("Impl1");
            return number + number + 1;
        }
        static int DuplicatorImpl2(int number)
        {
            Console.WriteLine("Impl2");
            return number * 3;
        }
        public delegate int Duplicator(int number);
    }
    delegate Portrait PaintPortrait(Photograph photograph);
    internal class Photograph
    {
    }

    internal class Portrait
    {


    }
    class Agbaawo
    {

        public Portrait BobsPaintPortraitMethod(Photograph photograph)
        {
            var portrait = new Portrait();

            // Do stuff with the photograph information in order to populate the portrait properties in Bob's style

            return portrait;
        }
        public Portrait StevesPaintPortraitMethod(Photograph photograph)
        {
            var portrait = new Portrait();

            // Do stuff with the photograph information in order to populate the portrait properties in Steve's style

            return portrait;
        }
        public PaintPortrait PortraitPaintingProperty { get; set; }
        public PaintPortrait PortraitPaintingProperty1 { get; set; }

        public string dosomething()
        {
            Agbaawo ss = new Agbaawo();
            ss.PortraitPaintingProperty1 = ss.StevesPaintPortraitMethod;
            ss.PortraitPaintingProperty = new PaintPortrait(ss.StevesPaintPortraitMethod);
            var restpho = new Photograph();
            var xyzs = ss.PortraitPaintingProperty1.Invoke(restpho);
            var xyz = ss.PortraitPaintingProperty(restpho);
            return "";
        }


    }
    public class MailServices : IMailer
    {
        public MailServices()
        {

        }
        public async Task<StatusMessage> SendMailAsync(Email email)
        {
            StatusMessage status = new StatusMessage();
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(email.SenderName, email.AddressFrom));
                message.To.Add(new MailboxAddress("", email.AddressTo));
                message.Subject = email.Subject;

                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = email.Body
                };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(email.Host, email.Port, true);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(email.Username, email.Password);

                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
                await Task.CompletedTask;
                status.status = "Success";
                status.message = "Success";
            }
            catch (Exception e)
            {
                status.status = "Failed";
                status.message = e.Message;
            }
            return status;
        }
        static string wwww(int msss)
        {
            //var www = default(TResult);
            return default(string);
        }
        static void wwwws(int msss)
        {
            //var www = default(TResult);
            // return default(string);
        }
        Func<int, string> waa = new Func<int, string>(wwww);
        Func<int, string> wss = wwww;
        Action<int> wssx = wwwws;
        Func<int, string> wsss = x => x.ToString();
        public string Ssse()
        {
            wwest(wss, wssx);
            string www = waa.Invoke(1);
            return www;
        }
        static void wwest(Func<int, string> wwewwe, Action<int> sss)
        {
            sss(1);
            wwewwe(1);
            List<int> numbers = new List<int> { 1, 2, 3, 8, 11, 20 };
            Func<int, bool> myPredicated = IsEvenNumber;
            Predicate<int> myPredicate = IsEvenNumber;
            var evenNumbers = numbers.FindAll(myPredicate);
            var evenNumberxs = numbers.Where(myPredicated);
            //passing a function as parameter to a function.
        }
        public static bool IsOdd(int number)
        {
            return number % 2 > 0;
        }

        public static bool IsEvenNumber(int number)
        {
            return (number & 1) == 0;
        }
    }

}
