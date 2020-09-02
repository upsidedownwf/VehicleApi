using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApiData.HelperModel;

namespace VehicleApiData.Interfaces
{
    public interface IMailer
    {
        Task<StatusMessage> SendMailAsync(Email email);
    }
}
