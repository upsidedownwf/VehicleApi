using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;

namespace VehicleApiServices.Services
{
    public class GenericServices<T>: IGeneric<T> where T: class
    {
        private readonly VehicleApiContext _context;

        public GenericServices(VehicleApiContext context)
        {
            _context = context;
        }


        public void Post(T model)
        {
            _context.Add(model);
            SaveChanges();
        }

        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            SaveChanges();
        }
        public void Delete(T model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            SaveChanges();
        }

        void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
