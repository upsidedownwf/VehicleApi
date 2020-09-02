using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleApiData.Interfaces;
using System.Net;
using VehicleApiData.HelperModel;
using MimeKit;
using MailKit.Net.Smtp;

namespace VehicleApiServices.Services
{
    public class MailServices : IMailer
    {
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
    }
}
