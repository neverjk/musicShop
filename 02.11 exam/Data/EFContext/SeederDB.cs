using _02._11_exam.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02._11_exam.Data.EFContext
{
    public class SeederDB
    {
        public static void SeedUsers(UserManager<DbUser> userManager,
            EFDbContext _context)
        {
            var count = userManager.Users.Count();
            if (count <= 0)
            {
                string email = "telesuk@gmail.com";
                var roleName = "Admin";

                var userprofile = new UserProfile
                {
                    FirstName = "admin",
                    LastName = "admin",
                    MiddleName = "admin",
                    RegistrationDate = DateTime.Now
                };
                var user = new DbUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+38(095)890-10-45",
                    UserProfile = userprofile
                };



                var result = userManager.CreateAsync(user, "Qwerty1-").Result;







                _context.UserProfiles.Add(userprofile);
                _context.SaveChanges();
                result = userManager.AddToRoleAsync(user, roleName).Result;




            }
        }
        public static void SeedTables(EFDbContext _context)
        {
            //if (_context.Categories.Count() <= 0)
            //{
            var category = new Category()
            {
                CategoryName = "Electronics"
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            //}

            var country = new Country()
            {
                CountryName = "Ukraine"
            };
            if (_context.Countries.Count() <= 0)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
            }
            var manufacturer = new Manufacturer()
            {
                ManufacturerName = "Lenovo",
                CountryId = _context.Countries.ToList()[0].Id
            };
            if (_context.Manufacturers.Count() <= 0)
            {
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();
            }

            var subcategory = new Subcategory()
            {
                SubcategoryName = "Notebooks",
                CategoryID = _context.Categories.ToList()[0].Id
            };
            if (_context.Subcategories.Count() <= 0)
            {
                _context.Subcategories.Add(subcategory);
                _context.SaveChanges();
            }
            var product = new Product()
            {
                ProductName = "B580",
                Description = "Notebook",
                ManufacturerId = _context.Manufacturers.ToList()[0].Id,
                SubcategoryId = _context.Subcategories.ToList()[0].Id,
                Price = 5000
            };
            if (_context.Products.Count() <= 0)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }
        public static void SeedRoles(RoleManager<DbRole> roleManager)
        {
            var count = roleManager.Roles.Count();
            if (count <= 0)
            {
                var roleName = "User";
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;



                roleName = "Admin";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
            }
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                //var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();


                //SeederDB.SeedRegions(context);
                //SeederDB.SeedRoles(managerRole);
                SeederDB.SeedTables(context);
            }
        }


    }
}
