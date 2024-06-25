using apbd_retake.Data;
using apbd_retake2.Models;

namespace apbd_retake2.Repositories;

public interface IActorRepository
{
    Task<Actor?> GetActorAsync(int actorId);
    Task<Actor> AddActor(string actorName, string actorSurname);
}

public class ActorRepository: IActorRepository
{
    private readonly AppDbContext _dbContext;

    public ActorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Actor?> GetActorAsync(int actorId)
    {
        return await _dbContext.Actors.FindAsync(actorId);
    }

    public async Task<Actor> AddActor(string actorName, string actorSurname)
    {
        var actor = new Actor
        {
            Name = actorName,
            Surname = actorSurname,
        };
        _dbContext.Actors.Add(actor);
        await _dbContext.SaveChangesAsync();
        return actor;
    }
}