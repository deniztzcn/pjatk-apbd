using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Models;

namespace apbd_tutorial08.Application.Repository;

public interface ITripRepository
{
    Task<PaginatedResult<Trip>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10);
    Task<List<Trip>> GetAllTripsAsync();
    Task AssignClientToTripAsync(int id, AssignClientDto assignClientDto);
    Task AddTrip(TripDto tripDto);
}