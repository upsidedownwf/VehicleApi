using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApi.Resources
{
    public class MakeResource
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ModelResource> Models { get; set; }
    }
}
