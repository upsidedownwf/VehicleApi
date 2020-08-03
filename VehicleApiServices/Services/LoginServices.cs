using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;

namespace VehicleApiServices.Services
{
    public class LoginServices : ILogin
    {
        private VehicleApiContext _context;

        public LoginServices(VehicleApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllLogin()
        {
            return _context.Users;
        }

        public Users GetLoginbyId(string ReferenceID)
        {
            return _context.Users.FirstOrDefault(x => x.ReferenceId == ReferenceID);
        }

        public Users GetSocialLoginUser(string Email, string ReferenceID, string Provider)
        {
            return _context.Users.FirstOrDefault(x=> x.Email== Email && x.ReferenceId== ReferenceID && x.Provider== Provider );
        }

        public void Register(Users model)
        {
            _context.Entry(model).State= EntityState.Added;
            Save();
        }

        public void UpdateUser(Users model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
