﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ATS.Models;

namespace ATS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Fieldset> Fieldset { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CateType> CateType { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Asset> Asset { get; set; }

        public DbSet<Status> Status { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Catagory> Catagory { get; set; }
       public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<Accessory> Accessory { get; set; }
        public DbSet<Consumable> Consumable { get; set; }
        public DbSet<Component> Component { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Department>()
            //    .HasRequired(s => s.Branch)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

    }
}