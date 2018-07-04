namespace WebApiTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiTest.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiTest.Models.MovieModelDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApiTest.Models.MovieModelDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Movies.AddOrUpdate(m => m.Title,
                new MovieModel
                {
                    Title = "Star Wars1",
                    ReleaseYear = 1977,
                    Runtime = 121
                },
                new MovieModel
                {
                    Title = "Star Wars2",
                    ReleaseYear = 1987,
                    Runtime = 122
                },
                new MovieModel
                {
                    Title = "Star Wars3",
                    ReleaseYear = 1997,
                    Runtime = 123
                });
        }
    }
}
