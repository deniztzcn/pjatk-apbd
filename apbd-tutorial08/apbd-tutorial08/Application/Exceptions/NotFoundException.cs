namespace apbd_tutorial08.Exceptions;

public abstract class NotFoundException(string message) : Exception(message);

public class ClientNotFound(int id): NotFoundException($"Client with id {id} not found.");

public class TripNotFound(int id) : NotFoundException($"Trip with id {id} not found.");
