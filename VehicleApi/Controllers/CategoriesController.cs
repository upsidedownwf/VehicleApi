﻿using AutoMapper;
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
    [Route("api/[controller]")]
    public class CategoriesController: Controller
    {
        private readonly IMapper mapper;
        private readonly ICategories _categories;
        public CategoriesController(ICategories categories, IMapper mapper)
        {
            this.mapper = mapper;
            _categories = categories;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
           var categories = _categories.GetAll();
            var result = mapper.Map<IEnumerable<Categories>, IEnumerable<CategoriesDto>>(categories);
            return Ok(result);
        }
        /// <summary>
        /// creates a new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A newly created product</returns>
        /// <response code="400">If the request is bad</response>
        /// <response code="201">Returns the newly created product</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostCategories([FromBody]CategoriesDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categories = mapper.Map<CategoriesDto, Categories>(model);
            _categories.AddCategory(categories);

            var category = _categories.GetCategoryById(categories.Id, model.Name);

            return Created(new Uri(Request.GetEncodedUrl() + "/" + category.Id), mapper.Map<Categories, CategoriesDto>(category));
        }

    }
}
