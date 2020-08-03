using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApiData.DomainModels;

namespace VehicleApi.Resources
{
    public class UsersResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Provider { get; set; }
        public string ReferenceId { get; set; }
        public string ImageUrl { get; set; }
        public int RoleID { get; set; }
    }
}
