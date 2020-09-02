using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApiData.HelperModel
{
    public class Email
    {
        public int Port { get; set; } = 465;
        public string Host { get; set; } = "smtp.gmail.com";
        public string SenderName { get; set; } = "Jon-Ajumobi Olamide D.";
        public string AddressFrom { get; set; } = "olamideajumobi@gmail.com";
        public string AddressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Username { get; set; } = "olamideajumobi@gmail.com";
        public string Password { get; set; } = "abacus01";
    }
}
