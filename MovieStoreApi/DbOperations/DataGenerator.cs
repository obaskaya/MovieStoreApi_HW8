using System;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Entities;

namespace MovieStoreApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                    return;
                // Creating Actor Data
                context.Actors.AddRange(
                    new Actor { Name = "Christian ", Surname = "Bale", },
                    new Actor { Name = "Heath ", Surname = "Ledger" },
                    new Actor { Name = "Gary ", Surname = "Oldman" },
                    new Actor { Name = "Willem", Surname = "Dafoe" },
                    new Actor { Name = "Jared", Surname = "Leto" },
                    new Actor { Name = "Lightning", Surname = "McQueen" },
                    new Actor { Name = "Tow", Surname = "Mater" }
                    );
                //Creating Director Data
                context.Directors.AddRange(

                    new Director { Name = "Christopher", Surname = "Nolan", },
                    new Director { Name = "Mary", Surname = "Harron" },
                    new Director { Name = "Brian", Surname = "Fee" }
                    );
                // Creating Genre Data
                context.Genres.AddRange(

                    new Genre { Name = "Action" },
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Animation" }
                    );
                context.SaveChanges();

                //Creating Movie Data
                context.Movies.AddRange(

                    new Movie
                    {
                        Name = "Batman Dark Knight",
                        PublishDate = new DateTime(2006,04,03),
                        Actors = context.Actors.Where(c => new[] { 1, 2, 3 }.Contains(c.Id)).ToList(),
                        DirectorId = 1,
                        GenreId = 1,
                        Price = 20.34
                    },
                    new Movie
                    {
                        Name = "American Psycho",
                        PublishDate = new DateTime(2002, 01, 02),
                        Actors = context.Actors.Where(c => new[] { 1, 4, 5 }.Contains(c.Id)).ToList(),
                        DirectorId = 2,
                        GenreId = 2,
                        Price = 10.99
                    },
                    new Movie
                    {
                        Name = "Cars",
                        PublishDate = new DateTime(2001, 09, 27),
                        Actors = context.Actors.Where(c => new[] { 6, 7 }.Contains(c.Id)).ToList(),
                        DirectorId = 3,
                        GenreId = 3,
                        Price = 15.20
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

