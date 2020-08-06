using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/sociallogin")]
    public class SocialLoginController: Controller
    {
        private readonly IMapper mapper;
        private readonly ILogin _login;
        public SocialLoginController(ILogin login, IMapper mapper)
        {
            this.mapper = mapper;
            _login = login;
        }
        [HttpGet]
        public IActionResult GetLogins()
        {
            var users = _login.GetAllLogin().ToList();
            //ObservableCollection<Make> sessions = new ObservableCollection<Make>(makes);
            return Ok(mapper.Map<List<Users>, List<UsersResource>>(users));
        }
        [HttpGet("{id}")]
        public IActionResult GetLoginByID(string id)
        {
            var user = _login.GetLoginbyId(id);
            if (user == null)
                return NotFound();
            return Ok(mapper.Map<Users, UsersResource>(user));
        }
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="userresource"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the item is not found</response>         
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Login([FromBody]UsersResource userresource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userresource.Password == null && userresource.ReferenceId != null && userresource.Provider != null)
            {
                var check = _login.GetSocialLoginUser(userresource.Email, userresource.ReferenceId, userresource.Provider);
                if (check == null)
                {
                    var users = mapper.Map<UsersResource, Users>(userresource);
                    _login.Register(users);
                    return Created(new Uri(Request.GetEncodedUrl() + "/" + users.Id), mapper.Map<Users, UsersResource>(users));
                }
                else
                {
                    if (check.FirstName == userresource.FirstName && check.LastName == userresource.LastName && userresource.ImageUrl== check.ImageUrl)
                    {
                        
                    }
                    else
                    {
                        check.LastName = userresource.LastName;
                        check.FirstName = userresource.FirstName;
                        check.ImageUrl = userresource.ImageUrl;
                        _login.UpdateUser(check);
                    }
                    return Ok(mapper.Map<Users, UsersResource>(check));
                }
            }
            return NotFound();
        }
    }
}

