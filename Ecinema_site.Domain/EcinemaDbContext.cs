using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ecinema_site.Domain.Entities;

namespace Ecinema_site.Domain
{
    public class EcinemaDbContext : IdentityDbContext<ApplicationUser>
    {
        public EcinemaDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
} 