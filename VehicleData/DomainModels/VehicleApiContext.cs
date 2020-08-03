using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApiData.DomainModels;

namespace VehicleApiData.DomainModels
{
    public  class VehicleApiContext : DbContext
    {
        public VehicleApiContext(DbContextOptions<VehicleApiContext> options) : base(options)
        {

        }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=JON;Database=Vehicle;Trusted_Connection=True;MultipleActiveResultSets=True;");
        //            }
        //        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Roles>(entity => {
                entity.HasKey(e => new { e.Id, e.Role });
            });

            builder.Entity<Users>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Email });
            });

            builder.Entity<Categories>(entity => {

                entity.HasKey(e=> new { e.Id, e.Name});
            });
            builder.Entity<Products>(entity=> {
                entity.HasKey(e=> new { e.Id, e.Title});
            });
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
