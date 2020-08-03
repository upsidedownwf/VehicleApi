using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.HelperModel;

namespace VehicleApiData.Interfaces
{
    public interface IPagedList<T> where T : class
    {
          PagedList<T> GetPage(PageParameters pageParameter);

    }
}
