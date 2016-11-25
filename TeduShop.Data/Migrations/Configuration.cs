namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            CreateProductCategorySample(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "manhtuan",
            //    Email = "manhtuan165@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Nguyễn Mạnh Tuấn"
            //};

            //manager.Create(user, "123456$");
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("manhtuan165@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

        }

        private void CreateProductCategorySample(TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {

                List<ProductCategory> lstProductCategory = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Name = "Điện Lạnh",
                    Alias = "dien-lanh",
                    Status= true
                },

                 new ProductCategory()
                {
                    Name = "Viễn Thông",
                    Alias = "vien-thong",
                    Status= true
                },

                  new ProductCategory()
                {
                    Name = "Đồ Gia Dụng",
                    Alias = "do-gia-dung",
                    Status= true
                },
                   new ProductCategory()
                {
                    Name = "Mỹ Phẩm",
                    Alias = "my-pham",
                    Status= true
                },

            };
                context.ProductCategories.AddRange(lstProductCategory);
                context.SaveChanges();

            }

        }
    }
}
