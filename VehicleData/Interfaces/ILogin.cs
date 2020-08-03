using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;

namespace VehicleApiData.Interfaces
{
    public interface ILogin
    {
        void Register(Users model);
        void UpdateUser(Users model);
        IEnumerable<Users> GetAllLogin();
        Users GetLoginbyId(string ReferenceID);
        Users GetSocialLoginUser(string Email, string ReferenceID, string Provider);
    }
}
