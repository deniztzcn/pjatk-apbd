using apbd_tutorial09.Repositories.Abstraction;

namespace apbd_tutorial09.Repositories.Implementation;

public class PatientRepository: IPatientRepository
{
    private readonly AppDbContext _dbContext;

    public PatientRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}