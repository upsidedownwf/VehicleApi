using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApiData.DomainModels
{
    public class Categories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(36), Key]
        public string Name { get; set; }
        [Required,StringLength(50)]
        public string Description { get; set; }
        [StringLength(36)]
        public string EnteredBy { get; set; }

    }
}
