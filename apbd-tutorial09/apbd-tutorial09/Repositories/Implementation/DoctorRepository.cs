using apbd_tutorial09.Repositories.Abstraction;

namespace apbd_tutorial09.Repositories.Implementation;

public class DoctorRepository: IDoctorRepository
{
    private readonly AppDbContext _dbContext;

    public DoctorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}