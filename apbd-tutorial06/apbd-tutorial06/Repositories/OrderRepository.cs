using System.Data.Common;
using System.Data.SqlClient;
using apbd_tutorial06.Models;

namespace apbd_tutorial06.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly IConfiguration _configuration;

    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Order?> GetOrder(WarehouseDTO warehouseDto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM [Order] WHERE IdProduct = @IdProduct AND Amount = @Amount AND CreatedAt < @CreatedAt";
        command.Parameters.AddWithValue("@IdProduct", warehouseDto.IdProduct);
        command.Parameters.AddWithValue("@Amount", warehouseDto.Amount);
        command.Parameters.AddWithValue("@CreatedAt", warehouseDto.CreatedAt);

        await connection.OpenAsync();

        using (var dr = await command.ExecuteReaderAsync())
        {
            if (await dr.ReadAsync())
            {
                return new Order()
                {
                    IdOrder = (int)dr["IdOrder"],
                    IdProduct = (int)dr["IdProduct"],
                    Amount = (int)dr["Amount"],
                    CreatedAt = (DateTime)dr["CreatedAt"],
                    FulfilledAt = (DateTime)dr["FulfilledAt"]
                };
            }
        }

        return null;
    }
}