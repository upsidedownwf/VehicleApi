﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleApiData.DomainModels;

namespace VehicleApiData.Migrations
{
    [DbContext(typeof(VehicleApiContext))]
    partial class VehicleApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleApiData.DomainModels.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(36);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EnteredBy")
                        .HasMaxLength(36);

                    b.HasKey("Id", "Name");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VehicleApiData.DomainModels.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("VehicleApiData.DomainModels.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("VehicleApiData.DomainModels.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(36);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(36);

                    b.Property<string>("ImageUrl");

                    b.Property<double>("Price");

                    b.HasKey("Id", "Title");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VehicleApiData.DomainModels.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasMaxLength(36);

                    b.Property<string>("RoleDescription")
                        .HasMaxLength(100);

                    b.HasKey("Id", "Role");

                    b.HasAlternateKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("VehicleApiData.DomainModels.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasMaxLength(36);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName")
                        .HasMaxLength(36);

                    b.Property<string>("Password")
                        .HasMaxLength(36);

                    b.Property<string>("Provider")
                        .HasMaxLength(36);

                    b.Property<string>("ReferenceId")
                        .HasMaxLength(500);

                    b.Property<int>("RoleID");

                    b.Property<string>("Username")
                        .HasMaxLength(36);

                    b.HasKey("Id", "Email");

                    b.HasAlternateKey("Email", "Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VehicleApiData.DomainModels.Model", b =>
                {
                    b.HasOne("VehicleApiData.DomainModels.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
