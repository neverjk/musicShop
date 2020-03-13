using _02._11_exam.Data.Models;
using _02._11_exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.EFContext
{
    public class EFDbContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
   DbUserRole, IdentityUserLogin<string>,
   IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        //public virtual DbSet<Car> Cars { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<FileModel> Files { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        

            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });



                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();



                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }

    //public class EFDbContext : DbContext
    //{
    //    public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
    //    {

    //    }

    //    public virtual DbSet<Car> Cars { get; set; }
    //    public virtual DbSet<Category> Categories { get; set; }
    //}
}
