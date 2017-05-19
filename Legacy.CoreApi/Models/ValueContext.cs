using Microsoft.EntityFrameworkCore;

namespace Legacy.CoreApi.Models
{
    public class ValueContext : DbContext
    {
        public ValueContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
    }
}
