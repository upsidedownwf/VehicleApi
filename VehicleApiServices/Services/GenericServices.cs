using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;
using System.Linq.Expressions;
using System.Linq;
using System.Transactions;
using System.Reflection;

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
                var x=Assembly.GetExecutingAssembly().GetManifestResourceNames();
                var y1= Assembly.GetExecutingAssembly().GetManifestResourceStream("");

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
        void transaction(T model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Entry(model).State = EntityState.Added;
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

        }
        void alttransaction(T model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    _context.Entry(model).State = EntityState.Added;
                    _context.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}
