using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApiData.DomainModels
{
    public class Products
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key, Required,StringLength(36)]
        public string Title { get; set; }
        [StringLength(36)]
        public string CategoryName { get; set; }
        public double Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
