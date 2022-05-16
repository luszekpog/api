using Microsoft.EntityFrameworkCore;

namespace CryptoAPI.Modules
{
    public class CryptoContext : DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Crypto> Coins{ get; set; }
    }
}
