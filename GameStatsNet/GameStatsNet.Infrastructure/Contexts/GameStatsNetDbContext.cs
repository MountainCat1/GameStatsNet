using GameStatsNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStatsNet.Infrastructure.Contexts
{
    public class GameStatsNetDbContext : DbContext
    {
        public SomeEntity SomeEntity { get; set; }
    
        public GameStatsNetDbContext(DbContextOptions<GameStatsNetDbContext> options) : base(options)
    {
        
    }
    }
}