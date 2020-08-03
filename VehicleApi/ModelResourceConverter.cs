using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Resources;
using VehicleApiData.DomainModels;

namespace VehicleApi
{
    public class ModelResourceConverter : IValueResolver<MakeResource, Make, IEnumerable<Model>>
    {

        public IEnumerable<Model> Resolve(MakeResource source, Make destination, IEnumerable<Model> destMember, ResolutionContext context)
        {
            var result = destination.Models ?? new List<Model>();
            // ICollection<Model> waso = result;


            ICollection<Model> c = (ICollection<Model>)result;
            return c;
        }
    }
}
