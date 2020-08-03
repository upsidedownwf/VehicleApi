using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApi.Resources
{
    public class CategoriesDto
    {
            public int Id { get; set; }
            [Required, StringLength(36)]
            public string Name { get; set; }
            [Required, StringLength(50)]
            public string Description { get; set; }
            [StringLength(36)]
            public string EnteredBy { get; set; }
    }
}
