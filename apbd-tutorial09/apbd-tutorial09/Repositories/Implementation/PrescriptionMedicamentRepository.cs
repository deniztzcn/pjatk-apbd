using apbd_tutorial09.Repositories.Abstraction;

namespace apbd_tutorial09.Repositories.Implementation;

public class PrescriptionMedicamentRepository: IPrescriptionMedicamentRepository
{
    private readonly AppDbContext _dbContext;

    public PrescriptionMedicamentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}