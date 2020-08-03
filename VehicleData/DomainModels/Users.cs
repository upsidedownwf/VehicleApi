using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApiData.DomainModels
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(36)]
        public string FirstName { get; set; }
        [StringLength(36)]
        public string LastName { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(36)]
        public string Username {get; set;}
        [StringLength(36)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(36)]
        public string Provider { get; set; }
        [StringLength(500)]
        public string ReferenceId { get; set; }
        public string ImageUrl { get; set; }
        public int RoleID { get; set; }
    }
}
