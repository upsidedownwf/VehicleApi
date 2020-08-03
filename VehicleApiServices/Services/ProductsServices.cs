using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;

namespace VehicleApiServices.Services
{
    public class ProductsServices: IProducts
    {
        private readonly VehicleApiContext _context;

        public ProductsServices(VehicleApiContext context)
        {
            _context = context;
        }

        public void AddProducts(Products model)
        {
            _context.Add(model);
            SaveChanges();
        }

        public IEnumerable<Products> GetAll()
        {
            return _context.Products;
        }

        public Products GetProductByTitle(int ID, string Title)
        {
            return _context.Products.FirstOrDefault(x=> x.Id== ID && x.Title== Title);
        }
        public Products GetProductByID(int ID)
        {
            return _context.Products.FirstOrDefault(x => x.Id == ID);
        }

        void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}
