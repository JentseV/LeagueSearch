using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class SummonerContext : DbContext
    {
        public SummonerContext(DbContextOptions<SummonerContext> options): base(options)
        {

        }

        public DbSet<Summoner> Summoners { get; set; } = null!;
    }
}
