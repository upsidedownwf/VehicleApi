using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApi.Resources
{
    public class ProductsResource
    {
        public int Id { get; set; }
        [Required, StringLength(36)]
        public string Title { get; set; }
        [StringLength(36)]
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
