namespace apbd_retake2.Exceptions;

public abstract class NotFoundException(string message): Exception(message);
public class MovieNotFound(int id): NotFoundException($"Movie with id {id} not found.");