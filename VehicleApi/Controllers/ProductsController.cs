using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VehicleApi.Helpers;
using VehicleApi.Resources;
using VehicleApiData.DomainModels;
using VehicleApiData.HelperModel;
using VehicleApiData.Interfaces;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController: Controller
    {
        private readonly IProducts _products;
        private readonly IMapper mapper;
        private readonly IGeneric<Products> post;

        public ProductsController(IProducts products, IMapper mapper, IGeneric<Products> post)
        {
            _products = products;
            this.mapper = mapper;
            this.post = post;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] PageParameters pageParameter, [FromHeader] string Pagination)
        {
            var model = new PageHeader();
            var models = new PageHeader();
            models=JsonConvert.DeserializeObject<PageHeader>(Pagination);
            JsonConvert.PopulateObject(Pagination, model);
            var products = _products.GetAll();
            var result = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsResource>>(products);
            var pagedproducts = PagedList<ProductsResource>.ToPagedList(result.AsQueryable(), pageParameter.PageNumber, pageParameter.PageSize);
            var metadata = new PageHeader
            {
                TotalCount= pagedproducts.TotalCount,
                PageSize= pagedproducts.PageSize,
                CurrentPage= pagedproducts.CurrentPage,
                TotalPages=pagedproducts.TotalPages,
                HasNext=pagedproducts.HasNext,
                HasPrevious= pagedproducts.HasPrevious
            };

            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(metadata));
            
            return Ok(pagedproducts);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var products = _products.GetProductByID(id);
            Expression<Func<Products, bool>> e = x => x.Id== id;
            var products2 = post.GetSingle(e);
            if(products == null)
            {
                return NotFound();
            }
            var result = mapper.Map<Products, ProductsResource>(products);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody]ProductsResource model)
        {
            if (!TryValidateModel(model))
            {
                return BadRequest(ModelState);
            }
            var products = mapper.Map<ProductsResource, Products>(model);
           // _products.AddProducts(products);
            post.Post(products);
            var product = _products.GetProductByTitle(products.Id, model.Title);
            return Created(new Uri(Request.GetEncodedUrl() + "/" + product.Id), product);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]ProductsResource productsResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _products.GetProductByID(id);

            if (product == null)
                return NotFound();
            mapper.Map(productsResource, product);
            post.Update(product);
            var result = mapper.Map<Products, ProductsResource>(product);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }
            else
                post.Delete(product);
            return Ok();

        }
    }
}
