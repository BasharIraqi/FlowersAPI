using Flowers.Models;
using Microsoft.EntityFrameworkCore;

namespace Flowers.DB
{
    public class FlowersDbContext :DbContext
    {

        public FlowersDbContext(DbContextOptions<FlowersDbContext> options):base(options)
        {
            
        }

        public DbSet<Flower> Flowers { get; set; }
    }
}
