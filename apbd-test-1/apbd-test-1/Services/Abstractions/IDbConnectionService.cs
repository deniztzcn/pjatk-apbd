namespace apbd_example_test.Services.Abstractions;

public interface IDbConnectionService
{
    string GetConnectionString { get; }
}