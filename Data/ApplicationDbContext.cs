using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ST10072500_CLDV6211_Part2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ST10072500_CLDV6211_Part2.Models.Product> Product { get; set; } = default!;

        public DbSet<ST10072500_CLDV6211_Part2.Models.Transaction> Transaction { get; set; } = default!;

        public DbSet<ST10072500_CLDV6211_Part2.Models.User> User { get; set; } = default!;

        public DbSet<ST10072500_CLDV6211_Part2.Models.TransactionHistory> TransactionHistory { get; set; } = default!;

        

    }
}
