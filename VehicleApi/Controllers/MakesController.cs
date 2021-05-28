using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;
using Microsoft.EntityFrameworkCore;
using VehicleApiServices;
using AutoMapper;
using VehicleApi.Resources;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;
using System.Collections.ObjectModel;
using VehicleApiServices.HelperModels;

namespace VehicleApi.Controllers
{
    [Route("api/makes")]
    public class MakesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMakes _makes;
        public MakesController(IMakes makes, IMapper mapper)
        {
            this.mapper= mapper;
            _makes = makes;
        }
       // MakesServices _makes = new MakesServices();
        //[HttpGet]
        //public IActionResult GetMakes()
        //{
        //    var makes = _makes.GetAllMakes();
        //    //ObservableCollection<Make> sessions = new ObservableCollection<Make>(makes);
        //    return Ok(mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(makes));
        //}
        [HttpGet("{id}")]
        public IActionResult GetMakeByID(int id)
        {

            string s = string.Empty;
            ExtensionMethod.doublestring("sss", out s);
            ExtensionMethod.Main();
            string xyz = s;
            var make = _makes.GetAllMakebyId(id);
            if (make == null)
                return NotFound();
            return Ok(mapper.Map<Make, MakeResource>(make));
        }

        [HttpPost]
        public ActionResult CreateMake([FromBody]MakeResource makeresource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var makes = mapper.Map<MakeResource, Make>(makeresource);
            _makes.AddMake(makes);

            var make = _makes.GetAllMakebyId(makes.Id);

            return Created(new Uri(Request.GetEncodedUrl() + "/" + make.Id), mapper.Map<Make, MakeResource>(make));
        }

        [HttpPut("{id}")]
        public ActionResult CreateMake(int id, [FromBody]MakeUpdateResource makeresource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var make = _makes.GetAllMakebyId(id);

            if (make == null)
                return NotFound();
            mapper.Map(makeresource, make);
            _makes.SaveChanges();
            var result = mapper.Map<Make, MakeResource>(make);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveMake(int id)
        {
            var make = _makes.GetAllMakebyId(id);
            if (make == null)
            {
                return NotFound();
            }
            else
                _makes.RemoveMake(make);
            return Ok();

        }
        [HttpGet]
        public IActionResult GetAllMasskes()
        {
            var getMakws = _makes.GetAllMakes1();

            return Ok(getMakws);
        }

        ////[HttpGet("wasoikeja")]
        //private IEnumerable<Make> hhh()
        //{
        //    var getMakws = _makes.GetAllMakes();

        //    foreach (var item in getMakws)
        //    {
        //        if (1 + 1 == 2)
        //            yield return item;
        //    }
        //}
    }
}
