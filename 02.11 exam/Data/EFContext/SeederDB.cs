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
            if (_context.Categories.Count() > 0)
            {
                return;
            }
            var categories = new List<Category>();
            categories.Add(new Category() { CategoryName = "Household appliances" });
            categories.Add(new Category() { CategoryName = "Laptops and computers" });
            categories.Add(new Category() { CategoryName = "Smartphones, TV and Electronics" });
            categories.Add(new Category() { CategoryName = "Tools and auto products" });
            _context.Categories.AddRange(categories);

            var countries = new List<Country>();
            countries.Add(new Country() { CountryName = "Ukraine" });
            countries.Add(new Country() { CountryName = "China" });
            countries.Add(new Country() { CountryName = "Korea" });
            countries.Add(new Country() { CountryName = "USA" });
            countries.Add(new Country() { CountryName = "Tatarstan" });
            countries.Add(new Country() { CountryName = "Germany" });

            _context.Countries.AddRange(countries);
            //_context.SaveChanges();

            var subcategories = new List<Subcategory>();
            subcategories.Add(new Subcategory() { SubcategoryName = "Large home appliances", Category = categories[0] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Kitchen Appliances", Category = categories[0] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Home and Clothing Care", Category = categories[0] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Laptops", Category = categories[1] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Computers", Category = categories[1] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Monitors", Category = categories[1] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Smartphones", Category = categories[2] });
            subcategories.Add(new Subcategory() { SubcategoryName = "TV sets", Category = categories[2] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Tablets", Category = categories[2] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Auto Electronics", Category = categories[3] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Car oils", Category = categories[3] });
            subcategories.Add(new Subcategory() { SubcategoryName = "Auto parts", Category = categories[3] });
            _context.Subcategories.AddRange(subcategories);

            var manufacturers = new List<Manufacturer>();
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Xiaomi", CountryName = countries[0] });
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Acer", CountryName = countries[1] });
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Samsung", CountryName = countries[2] });
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Bosch", CountryName = countries[3] });
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Tesla", CountryName = countries[4] });
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Prime-X", CountryName = countries[5] });
            manufacturers.Add(new Manufacturer() { ManufacturerName = "Bardahl", CountryName = countries[5] });
            _context.Manufacturers.AddRange(manufacturers);
            //_context.SaveChanges();

            var products = new List<Product>();
            products.Add(new Product() { ProductName = "Холодильник BOSCH KGN39VI306", Description = "Цвет: Нержавеющая сталь\nТип холодильника: Двухкамерный\nСистема разморозки No Frost (Frost Free): Холодильное+морозильное отделения\nПолезный объем холодильной камеры: 279 л\nПолезный объем морозильной камеры: 87 л\nКоличество компрессоров: 1\nТип управления: Электронное", Image = "https://i2.rozetka.ua/goods/15121098/bosch_kgn39vi306_images_15121098308.jpg", Video = "https://www.youtube.com/watch?v=NO1gBt10Wyg&feature=emb_title", Price = 15799, ManufacturerName = manufacturers[3], SubcategoryName = subcategories[0] });

            products.Add(new Product() { ProductName = "Электрочайник BOSCH TWK3A013", Description = "Материал корпуса: Пластик\nШкала уровня воды: Со шкалой\nТип нагревательного элемента: Скрытый (диск)\nТип: Обычный\nЗащита: Выключение при снятии с базы\nМощность: 2400 Вт", Image = "https://i2.rozetka.ua/goods/818940/2528227_images_818940149.jpg", Video = "https://www.youtube.com/watch?v=HzL4w3V1KFk", Price = 799, ManufacturerName = manufacturers[3], SubcategoryName = subcategories[1] });

            products.Add(new Product() { ProductName = "Робот-пылесос Xiaomi Mijia Mi Robot Vacuum Cleaner SDJQR02RR (SKV4022GL) (Международная версия)", Description = "Тип: Робот-пылесос\nТип уборки: Сухая\nВид поверхности: Ковер с низким ворсом\nЭнергопотребление, Вт/ч: 55 Вт\nПитание: Аккумулятор", Image = "https://i2.rozetka.ua/goods/1871168/xiaomi_skv4000cm_images_1871168582.jpg", Video = "", Price = 7999, ManufacturerName = manufacturers[0], SubcategoryName = subcategories[2] });

            products.Add(new Product() { ProductName = "Ноутбук Acer Aspire 5 A515-54G-50EQ (NX.HN5EU.00J) Pure Silver", Description = "Экран 15.6 IPS(1920x1080) Full HD, матовый / Intel Core i5 - 10210U(1.6 - 4.2 ГГц) / RAM 8 ГБ / SSD 512 ГБ / nVidia GeForce MX250, 2 ГБ / без ОД / LAN / Wi - Fi / Bluetooth / веб - камера / Linux / 1.8 кг / серебристый", Image = "https://i8.rozetka.ua/goods/16717953/copy_acer_nx_hfreu_038_5e395313e5c5a_images_16717953750.jpg", Video = "", Price = 16999, ManufacturerName = manufacturers[1], SubcategoryName = subcategories[3] });

            products.Add(new Product() { ProductName = "Acer Veriton S2660G (DT.VQXME.007)", Description = "Intel Core i5-8400 (2.8 - 4.0 ГГц) / RAM 8 ГБ / HDD 1 ТБ / Intel UHD Graphics 630 / без ОД / LAN / Endless OS", Image = "https://i1.rozetka.ua/goods/9317524/copy_acer_dt_vqxme_008_5c0e73591eaca_images_9317524209.jpg", Video = "", Price = 10199, ManufacturerName = manufacturers[1], SubcategoryName = subcategories[4] });

            products.Add(new Product() { ProductName = "Mонитор 23.5 Samsung Curved C24F396F(LC24F396FHIXCI) - HDMI - кабель в комплекте", Description = "Диагональ дисплея: 23.5\nМаксимальное разрешение дисплея: 1920 x 1080\nТип матрицы: VA\nВремя реакции матрицы: 4 мс", Image = "https://i2.rozetka.ua/goods/16884017/samsung_c24f396f_images_16884017291.jpg", Video = "https://www.youtube.com/watch?v=QKC3iOSJz5w", Price = 3299, ManufacturerName = manufacturers[2], SubcategoryName = subcategories[5] });

            products.Add(new Product() { ProductName = "Мобильный телефон Samsung Galaxy S20 Ultra 12/128GB Cosmic Gray (SM-G988BZADSEK)", Description = "Экран (6.9, Dynamic AMOLED 2X, 3200x1440) / Samsung Exynos 990(2 x 2.73 ГГц + 2 x 2.5 ГГц + 4 x 2.0 ГГц) / основная квадро - камера: 108 Мп + 48 Мп + 12 Мп + ToF, фронтальная: 40 Мп / RAM 12 ГБ / 128 ГБ встроенной памяти + microSD(до 1 ТБ) / 3G / LTE / 5G / GPS / поддержка 2х SIM-карт(Nano - SIM) / Android 10.0(Q) / 5000 мА* ч", Image = "https://i8.rozetka.ua/goods/16847767/samsung_galaxy_s20_ultra_gray_sm_g988bzadsek_images_16847767567.jpg", Video = "https://www.youtube.com/watch?v=BM6fFXgaXRc", Price = 37999, ManufacturerName = manufacturers[2], SubcategoryName = subcategories[6] });

            products.Add(new Product() { ProductName = "Телевизор Samsung UE43N5000AUXUA", Description = "Диагональ экрана: 43\nПоддержка Smart TV: без Smart TV\nРазрешение: 1920x1080\nБеспроводной интерфейс: без Wi-Fi\nДиапазоны цифрового тюнера: DVB-C", Image = "https://i8.rozetka.ua/goods/15405466/samsung_ue43n5000auxua_images_15405466938.jpg", Video = "https://www.youtube.com/watch?v=pKxEv3bKU6U", Price = 7499, ManufacturerName = manufacturers[2], SubcategoryName = subcategories[7] });

            products.Add(new Product() { ProductName = "Планшет Xiaomi Mi Pad 4 Wi-Fi 4/64GB (без OTA обновлений)", Description = "Экран 8 IPS(1920x1200) емкостный,               MultiTouch / Qualcomm Snapdragon 660 MSM8976 Plus(2.2 ГГц + 1.84 ГГц) / RAM 4 ГБ / 64 ГБ встроенной памяти / Wi - Fi / Bluetooth 5.0 / основная камера 13 Мп,                фронтальная 5 Mп / Android 8.1(Oreo) / 342 г / черный", Image = "https://i2.rozetka.ua/goods/12941289/xiaomi_mipad4_wi_fi_4_64gb_black_images_12941289432.jpg", Video = "", Price = 4799, ManufacturerName = manufacturers[0], SubcategoryName = subcategories[8] });

            products.Add(new Product() { ProductName = "Штатное зеркало с монитором Prime-X 043/102 на штатном креплении", Description = "Максимальное разрешение видео: FullHD (1920x1080)\nКоличество камер: 1\nВстроенный GPS: Нет", Image = "https://i2.rozetka.ua/goods/11297577/75239022_images_11297577978.jpg", Video = "", Price = 1800, ManufacturerName = manufacturers[5], SubcategoryName = subcategories[9] });

            products.Add(new Product() { ProductName = "Моторное масло BARDAHL XTC 10W40 4л. 36242", Description = "BARDAHL XTC 10W40 4л. 36242", Image = "https://i8.rozetka.ua/goods/15767273/162018032_images_15767273649.jpg", Video = "", Price = 772, ManufacturerName = manufacturers[5], SubcategoryName = subcategories[10] });

            products.Add(new Product() { ProductName = "Автомобильная Лампа Tesla Н4 H/L 6000K Inspire 17140", Description = "Вид: Биксеноновые\nМощность: 40 Вт\nКоличество ламп в упаковке: 1", Image = "https://i1.rozetka.ua/goods/14688772/136517408_images_14688772944.jpg", Video = "", Price = 503, ManufacturerName = manufacturers[5], SubcategoryName = subcategories[11] });
            _context.Products.AddRange(products);
            _context.SaveChanges();


            //var category = new Category()
            //{
            //    CategoryName = "Electronics"
            //};
            //if (_context.Categories.Count() <= 0)
            //{
            //    _context.Categories.Add(category);
            //    _context.SaveChanges();
            //}
            //var country = new Country()
            //{
            //    CountryName = "Ukraine"
            //};
            //if (_context.Countries.Count() <= 0)
            //{
            //    _context.Countries.Add(country);
            //    _context.SaveChanges();
            //}
            //var manufacturer = new Manufacturer()
            //{
            //    ManufacturerName = "Lenovo",
            //    CountryId = _context.Countries.ToList()[0].Id
            //};
            //if (_context.Manufacturers.Count() <= 0)
            //{
            //    _context.Manufacturers.Add(manufacturer);
            //    _context.SaveChanges();
            //}
            //var subcategory = new Subcategory()
            //{
            //    SubcategoryName = "Notebooks",
            //    CategoryID = _context.Categories.ToList()[0].Id
            //};
            //if (_context.Subcategories.Count() <= 0)
            //{
            //    _context.Subcategories.Add(subcategory);
            //    _context.SaveChanges();
            //}
            //var product = new Product()
            //{
            //    ProductName = "B580",
            //    Description = "Notebook",
            //    ManufacturerId = _context.Manufacturers.ToList()[0].Id,
            //    SubcategoryId = _context.Subcategories.ToList()[0].Id,
            //    Price = 5000
            //};
            //if (_context.Products.Count() <= 0)
            //{
            //    _context.Products.Add(product);
            //    _context.SaveChanges();
            //}
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
                SeederDB.SeedRoles(managerRole);
                SeederDB.SeedTables(context);
            }
        }


    }
}
