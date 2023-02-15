using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace MovieStoreApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie> PurchasedMovies { get; set; }
        public ICollection<Genre> FavoriteGenres { get; set; }
        
        public MailAddress Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}

