using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;

namespace VehicleApiData.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Categories> GetAll();
        void AddCategory(Categories make);
        Categories GetCategoryById(int ID, string Name);
    }
}
