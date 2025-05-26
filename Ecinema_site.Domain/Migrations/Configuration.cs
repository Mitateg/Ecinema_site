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

            // Seed movies if none exist
            if (!context.Movies.Any())
            {
                context.Movies.AddOrUpdate(
                    m => m.Title,
                    new Movie
                    {
                        Title = "Alien",
                        Description = "In deep space, the crew of the commercial starship Nostromo is awakened from their cryo-sleep capsules halfway through their journey home to investigate a distress call from an alien vessel.",
                        Year = 1979,
                        Genre = "Action, Adventure, Horror",
                        Rating = 4.5,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_1.png",
                        VideoUrl = "/Content/Videos/sample.mp4"
                    },
                    new Movie
                    {
                        Title = "Fight Club",
                        Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                        Year = 1999,
                        Genre = "Drama, Thriller",
                        Rating = 4.7,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_2.png",
                        VideoUrl = "/Content/Videos/sample.mp4"
                    },
                    new Movie
                    {
                        Title = "The Goonies",
                        Description = "A group of young misfits called The Goonies discover an ancient map and set out on an adventure to find a legendary pirate's long-lost treasure.",
                        Year = 1985,
                        Genre = "Adventure, Comedy",
                        Rating = 4.8,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_3.png",
                        VideoUrl = "/Content/Videos/sample.mp4"
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                        Year = 1994,
                        Genre = "Drama",
                        Rating = 4.9,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_4.png",
                        VideoUrl = "/Content/Videos/sample.mp4"
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival .",
                        Year = 2014,
                        Genre = "Adventure, Drama, Sci-Fi",
                        Rating = 4.6,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_5.png",
                        VideoUrl = "/Content/Videos/sample.mp4"
                    }
                );
            }
        }
    }
}
