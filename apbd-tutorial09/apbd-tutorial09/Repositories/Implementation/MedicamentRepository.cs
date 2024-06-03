namespace apbd_tutorial09.Repositories.Abstraction;

public class MedicamentRepository: IMedicamentRepository
{
    private readonly AppDbContext _dbContext;

    public MedicamentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }    
}