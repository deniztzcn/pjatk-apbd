using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Application.Repository;
using apbd_tutorial08.Context;
using apbd_tutorial08.Exceptions;
using apbd_tutorial08.Models;
using Microsoft.EntityFrameworkCore;
using TripApp.Application.Mappers;

namespace apbd_tutorial08.Infrastructure.Repository;

public class TripRepository: ITripRepository
{
    private readonly Apbd08Context _apbd08Context;

    public TripRepository(Apbd08Context apbd08Context)
    {
        _apbd08Context = apbd08Context;
    }
    
    public async Task<PaginatedResult<Trip>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10)
    {
        var tripsQuery = _apbd08Context.Trips
            .Include(e => e.ClientTrips).ThenInclude(e => e.IdClientNavigation)
            .Include(e => e.IdCountries)
            .OrderBy(e => e.DateFrom);

        var tripsCount = await tripsQuery.CountAsync();
        var totalPages = tripsCount / pageSize;
        var trips = await _apbd08Context.Trips
            .Include(e => e.ClientTrips).ThenInclude(e => e.IdClientNavigation)
            .Include(e => e.IdCountries)
            .OrderBy(e => e.DateFrom)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<Trip>
        {
            PageSize = pageSize,
            PageNum = page,
            AllPages = totalPages,
            Data = trips
        };
    }
    
    public async Task<List<Trip>> GetAllTripsAsync()
    {
        return await _apbd08Context.Trips
            .Include(e => e.ClientTrips).ThenInclude(e => e.IdClientNavigation)
            .Include(e => e.IdCountries)
            .OrderByDescending(e => e.DateFrom)
            .ToListAsync();
    }

    public async Task AssignClientToTripAsync(int id, AssignClientDto assignClientDto)
    {
        var client = await _apbd08Context.Clients.FirstOrDefaultAsync(c => c.Pesel.Equals(assignClientDto.Pesel));

        if (client != null)
        {
            throw new ClientAlreadyExists(assignClientDto.Pesel);
        }

        var trip = await _apbd08Context.Trips.Include(t => t.ClientTrips)
            .FirstOrDefaultAsync(t => t.IdTrip == id);

        if (trip == null)
        {
            throw new TripNotFound(id);
        }

        if (trip.DateFrom < DateTime.Now)
        {
            throw new TripAlreadyMade(id);
        }

        if (trip.ClientTrips.Any(c => c.IdClientNavigation.Pesel.Equals(assignClientDto.Pesel)))
        {
            throw new ClientAlreadyRegisteredTrip(assignClientDto.Pesel);
        }

        assignClientDto.IdTrip = id;

        await _apbd08Context.Clients.AddAsync(assignClientDto.MapToClient());
        await _apbd08Context.ClientTrips.AddAsync(assignClientDto.MapToClientTrip());

        await _apbd08Context.SaveChangesAsync();    

    }

    public async Task AddTrip(TripDto tripDto)
    {
        var trip = tripDto.MapToTrip();
        await _apbd08Context.Trips.AddAsync(trip);
        await _apbd08Context.SaveChangesAsync();
    }

    
}