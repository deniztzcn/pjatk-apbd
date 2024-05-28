using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Models;

namespace apbd_tutorial08.Application.Services.Abstraction;

public interface ITripService
{
    Task<PaginatedResult<TripDto>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10);
    Task<List<TripDto>> GetAllTripsAsync();
    Task AssignClientToTripAsync(int id, AssignClientDto assignClientDto);

    Task AddTrip(TripDto tripDto);
}