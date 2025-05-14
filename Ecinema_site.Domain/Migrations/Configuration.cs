namespace Ecinema_site.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ecinema_site.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Ecinema_site.Domain.EcinemaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ecinema_site.Domain.EcinemaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Seed a default admin user if it doesn't exist
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var adminEmail = "admin@ecinema.com";
            var adminUser = userManager.FindByName(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };
                userManager.Create(adminUser, "Admin123!");
            }
        }
    }
}
