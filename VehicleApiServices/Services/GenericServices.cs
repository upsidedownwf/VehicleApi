using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;
using System.Linq.Expressions;
using System.Linq;

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
        public void PostMore(T model)
        {
            // Type t = typeof(T);
            foreach (var property in model.GetType().GetProperties())
            {
                var propertyvalue = property.GetValue(model);
                if (propertyvalue != null)
                {
                    _context.Entry(propertyvalue).State = EntityState.Added;
                }
            }
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
        public T GetSingle(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match);
        }
    }
}
