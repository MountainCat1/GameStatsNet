using GameStatsNet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStatsNet.Api.Controllers;

[ApiController]
[Route("api/game-matches")]
public class GameMatchController : ControllerBase
{
    private readonly MongoDbContext _mongoDbContext;
    private readonly ILogger<GameMatchController> _logger;
    
    public GameMatchController(MongoDbContext mongoDbContext, ILogger<GameMatchController> logger)
    {
        _mongoDbContext = mongoDbContext;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMatch()
    {
        var collection = _mongoDbContext.GetGameMatches();

        var id = Guid.NewGuid();
        _logger.LogInformation("Creating new game match with id {Id}", id);
        await collection.InsertOneAsync(new GameMatch()
        {
            Id = id,
            FinishedAt = DateTime.Now,
            StartedAt = DateTime.Now - TimeSpan.FromMinutes(new Random().Next(1, 30)),
        });
        
        return Ok();
    }
}