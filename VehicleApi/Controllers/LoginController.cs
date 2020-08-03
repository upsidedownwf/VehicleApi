using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Resources;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;

namespace VehicleApi.Controllers
{
    public class LoginController: Controller
    {
        private readonly IMapper mapper;
        private readonly ILogin _login;
        public LoginController(ILogin login, IMapper mapper)
        {
            this.mapper = mapper;
            _login = login;
        }
       
    }
}
