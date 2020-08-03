using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;

namespace VehicleApiServices.Services
{
    public class CategoriesServices : ICategories
    {
        private readonly VehicleApiContext _context;

        public CategoriesServices(VehicleApiContext context)
        {
            _context = context;
        }
        public IEnumerable<Categories> GetAll()
        {
            return _context.Categories;
        }
        public void AddCategory(Categories make)
        {
            _context.Add(make);
            SaveChanges();
        }
        void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Categories GetCategoryById(int ID, string Name)
        {
            return _context.Categories.FirstOrDefault(x=> x.Id== ID && x.Name==Name);
        }
    }
}
