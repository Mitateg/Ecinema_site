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
                    Email = adminEmail,
                    FirstName = "John",
                    LastName = "Smith",
                    ProfilePicture = "/Content/Images/Profiles/default-profile.png"
                };
                userManager.Create(adminUser, "Admin123!");
            }
            else
            {
                // Update existing admin user
                adminUser.FirstName = "John";
                adminUser.LastName = "Smith";
                adminUser.ProfilePicture = "/Content/Images/Profiles/default-profile.png";
                userManager.Update(adminUser);
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
                        VideoUrl = "/Content/Videos/alien.mp4"
                    },
                    new Movie
                    {
                        Title = "Back to the Future",
                        Description = "Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.",
                        Year = 1985,
                        Genre = "Sci-Fi, Adventure",
                        Rating = 4.7,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_2.png",
                        VideoUrl = "/Content/Videos/back_to_the_future.mp4"
                    },
                    new Movie
                    {
                        Title = "The Goonies",
                        Description = "A group of young misfits called The Goonies discover an ancient map and set out on an adventure to find a legendary pirate's long-lost treasure.",
                        Year = 1985,
                        Genre = "Adventure, Comedy",
                        Rating = 4.8,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_3.png",
                        VideoUrl = "/Content/Videos/the_goonies.mp4"
                    },
                    new Movie
                    {
                        Title = "Jurassic Park",
                        Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                        Year = 1990,
                        Genre = "Action, Adventure",
                        Rating = 4.9,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_4.png",
                        VideoUrl = "/Content/Videos/jurassic_park.mp4"
                    },
                    new Movie
                    {
                        Title = "Star Wars",
                        Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station.",
                        Year = 1977,
                        Genre = "Sci-Fi, Action",
                        Rating = 4.6,
                        PosterUrl = "/Content/Images/Movies/Movie_poster_5.png",
                        VideoUrl = "/Content/Videos/star_wars.mp4"
                    }
                );
            }

            // Always update existing movies to correct titles, genres, descriptions, and video URLs based on PosterUrl
            var movie1 = context.Movies.FirstOrDefault(m => m.PosterUrl == "/Content/Images/Movies/Movie_poster_1.png");
            if (movie1 != null)
            {
                movie1.Title = "Alien";
                movie1.Genre = "Action, Adventure, Horror";
                movie1.Description = "In deep space, the crew of the commercial starship Nostromo is awakened from their cryo-sleep capsules halfway through their journey home to investigate a distress call from an alien vessel.";
                movie1.VideoUrl = "/Content/Videos/alien.mp4";
            }
            var movie2 = context.Movies.FirstOrDefault(m => m.PosterUrl == "/Content/Images/Movies/Movie_poster_2.png");
            if (movie2 != null)
            {
                movie2.Title = "Back to the Future";
                movie2.Genre = "Sci-Fi, Adventure";
                movie2.Description = "Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.";
                movie2.VideoUrl = "/Content/Videos/back_to_the_future.mp4";
            }
            var movie3 = context.Movies.FirstOrDefault(m => m.PosterUrl == "/Content/Images/Movies/Movie_poster_3.png");
            if (movie3 != null)
            {
                movie3.Title = "The Goonies";
                movie3.Genre = "Adventure, Comedy";
                movie3.Description = "A group of young misfits called The Goonies discover an ancient map and set out on an adventure to find a legendary pirate's long-lost treasure.";
                movie3.VideoUrl = "/Content/Videos/the_goonies.mp4";
            }
            var movie4 = context.Movies.FirstOrDefault(m => m.PosterUrl == "/Content/Images/Movies/Movie_poster_4.png");
            if (movie4 != null)
            {
                movie4.Title = "Jurassic Park";
                movie4.Genre = "Action, Adventure";
                movie4.Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.";
                movie4.VideoUrl = "/Content/Videos/jurassic_park.mp4";
            }
            var movie5 = context.Movies.FirstOrDefault(m => m.PosterUrl == "/Content/Images/Movies/Movie_poster_5.png");
            if (movie5 != null)
            {
                movie5.Title = "Star Wars";
                movie5.Genre = "Sci-Fi, Action";
                movie5.Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station.";
                movie5.VideoUrl = "/Content/Videos/star_wars.mp4";
            }
            context.SaveChanges();
        }
    }
}
