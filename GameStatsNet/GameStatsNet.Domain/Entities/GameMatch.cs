using Catut.Domain.Abstractions;

namespace GameStatsNet.Domain.Entities
{
    public class GameMatch : Entity
    {
        public Guid Id { get; set; }
        
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}