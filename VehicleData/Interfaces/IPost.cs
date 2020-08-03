using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApiData.Interfaces
{
    public interface IPost<T> where T: class
    {
        void Post(T model);
        void Update(T model);
        void Delete(T model);
    }
}
