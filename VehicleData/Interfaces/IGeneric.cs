using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VehicleApiData.Interfaces
{
    public interface IGeneric<T> where T: class
    {
        void Post(T model);
        void PostMore(T model);
        void Update(T model);
        void Delete(T model);
        IEnumerable<T> Get(Expression<Func<T, bool>> match);
        T GetSingle(Expression<Func<T, bool>> match);
    }
}
