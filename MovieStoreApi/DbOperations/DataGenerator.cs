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

                context.Actors.AddRange(
                    new Actor { Name = "Christian ", Surname = "Bale", },
                    new Actor { Name = "Heath ", Surname = "Ledger" },
                    new Actor { Name = "Gary ", Surname = "Oldman" },
                    new Actor { Name = "Willem", Surname = "Dafoe" },
                    new Actor { Name = "Jared", Surname = "Leto" },
                    new Actor { Name = "Lightning", Surname = "McQueen" },
                    new Actor { Name = "Tow", Surname = "Mater" }
                    );
                context.Directors.AddRange(

                    new Director { Name = "Christopher", Surname = "Nolan", },
                    new Director { Name = "Mary", Surname = "Harron" },
                    new Director { Name = "Brian", Surname = "Fee" }
                    );
                context.Genres.AddRange(

                    new Genre { Name = "Action" },
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Animation" }
                    );
                context.SaveChanges();
                context.Movies.AddRange(

                    new Movie
                    {
                        Name = "Batman Dark Knight",
                        Year = 2008,
                        Actors = context.Actors.Where(c => new[] { 1, 2, 3 }.Contains(c.Id)).ToList(),
                        DirectorId = 1,
                        GenreId = 1,
                        Price = 20
                    },
                    new Movie
                    {
                        Name = "American Psycho",
                        Year = 2001,
                        Actors = context.Actors.Where(c => new[] { 1, 4, 5 }.Contains(c.Id)).ToList(),
                        DirectorId = 2,
                        GenreId = 2,
                        Price = 10
                    },
                    new Movie
                    {
                        Name = "Cars",
                        Year = 2006,
                        Actors = context.Actors.Where(c => new[] { 6, 7 }.Contains(c.Id)).ToList(),
                        DirectorId = 3,
                        GenreId = 3,
                        Price = 15
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

