using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApiData.HelperModel;
using VehicleApiData.Interfaces;

namespace VehicleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMailer _mailer;

        public MailController(IMailer mailer)
        {
            _mailer = mailer;
        }
        [HttpPost]
        public async Task<IActionResult> SendMailAsync(Email email)
        {
            //var mail = new Email()
            //{
            //    AddressTo = "ajumobiolamide@gmail.com",
            //    Subject = "Activate your new Powersoft account",
            //    Body = "<div><p>Hi " +
            //                ", your Powersoft account  has been created. We just need you to click on the link below to activate your account to complete your signup.<p><br/>" +
            //                "<p><a href=\"\"</a></p></div> "
            //};
           var status=await Task.Run(()=>_mailer.SendMailAsync(email));
            return Ok(status);
        }
    }
}
