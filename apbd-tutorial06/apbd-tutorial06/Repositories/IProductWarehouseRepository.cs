namespace apbd_tutorial06.Repositories;

public interface IProductWarehouseRepository
{
    public Task<bool> IsIdOrderExist(int idOrder);
}