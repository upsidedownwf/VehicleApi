using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApiData.DomainModels
{
    [Table("Roles")]
    public class Roles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(36)]
        [Required]
        public string Role { get; set; }
        [StringLength(100)]
        public string RoleDescription { get; set; }
    }
}
