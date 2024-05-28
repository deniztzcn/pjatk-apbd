using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Application.Repository;
using apbd_tutorial08.Application.Services.Abstraction;
using apbd_tutorial08.Models;
using TripApp.Application.Mappers;

namespace apbd_tutorial08.Application.Services.Implementation;

public class TripService: ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    
    public async Task<PaginatedResult<TripDto>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10)
    {
        if (page < 1) page = 1;
        if (pageSize < 10) page = 10;
        var result = await _tripRepository.GetPaginatedTripsAsync(page, pageSize);

        var mappedTrips = new PaginatedResult<TripDto>
        {
            AllPages = result.AllPages,
            Data = result.Data.Select(trip => trip.MapToTripDto()).ToList(),
            PageNum = result.PageNum,
            PageSize = result.PageSize
        };

        return mappedTrips;
    }
    
    public async Task<List<TripDto>> GetAllTripsAsync()
    {
        var trips = await _tripRepository.GetAllTripsAsync();
        var mappedTrips = trips.Select(trip => trip.MapToTripDto()).ToList();
        return mappedTrips;
    }

    public async Task AssignClientToTripAsync(int id, AssignClientDto assignClientDto)
    {
        await _tripRepository.AssignClientToTripAsync(id, assignClientDto);
    }

    public async Task AddTrip(TripDto tripDto)
    {
        await _tripRepository.AddTrip(tripDto);
    }
}