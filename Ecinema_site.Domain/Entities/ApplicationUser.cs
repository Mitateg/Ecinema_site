using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Ecinema_site.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsPremium { get; set; }
        public virtual ICollection<Movie> WatchedMovies { get; set; }

        public ApplicationUser()
        {
            WatchedMovies = new HashSet<Movie>();
        }
    }
} 