using GameStatsNet.Infrastructure.Contexts;
using Catut.Application.Abstractions;

namespace GameStatsNet.Application.Services;

// TODO: Replace placeholder
public interface ISomeEntityUnitOfWork : IUnitOfWork<GameStatsNetDbContext>
{
}

public class SomeEntityUnitOfWork : UnitOfWork<GameStatsNetDbContext>, ISomeEntityUnitOfWork
{
    public SomeEntityUnitOfWork(GameStatsNetDbContext context) : base(context)
    {
    }
}

