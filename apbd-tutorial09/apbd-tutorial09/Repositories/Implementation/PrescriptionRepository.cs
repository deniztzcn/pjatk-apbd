using apbd_tutorial09.DTOs;
using apbd_tutorial09.Exceptions;
using apbd_tutorial09.Mappers;
using apbd_tutorial09.Models;
using apbd_tutorial09.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace apbd_tutorial09.Repositories.Implementation;

public class PrescriptionRepository: IPrescriptionRepository
{
    private readonly AppDbContext _dbContext;

    public PrescriptionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PrescriptionResponseDto> AddPrescriptionWithPatient(PrescriptionRequestDto prescriptionRequestDto)
    {
        var patient = _dbContext.Patients.AnyAsync(p => p.IdPatient == prescriptionRequestDto.Patient.IdPatient);
        if (!patient.Result)
        {
            _dbContext.Patients.AddAsync(prescriptionRequestDto.Patient.RequestDtoToPatient());
            _dbContext.SaveChangesAsync();
        }

        foreach (var medicament in prescriptionRequestDto.Medicaments)
        {
            if (!_dbContext.Medicaments.AnyAsync(m => m.IdMedicament == medicament.IdMedicament).Result)
            {
                throw new MedicamentNotFound(medicament.IdMedicament);
            }
        }
    }
}