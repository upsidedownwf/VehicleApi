using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;

namespace VehicleApiData.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Products> GetAll();
        void AddProducts(Products model);
       Products GetProductByTitle(int ID, string Title);
        Products GetProductByID(int ID);
    }
}
