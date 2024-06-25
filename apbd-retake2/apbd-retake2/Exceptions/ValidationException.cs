namespace apbd_retake2.Exceptions;

public class ValidationException(string message): Exception(message);
public class CharacterNameAlreadyExistsInTheMovie(): ValidationException("Character name already exists in the movie.");