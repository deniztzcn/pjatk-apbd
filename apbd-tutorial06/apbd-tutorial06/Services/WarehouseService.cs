using apbd_tutorial06.Models;
using apbd_tutorial06.Repositories;

namespace apbd_tutorial06.Services;

public class WarehouseService: IWarehouseService
{
    private IProductRepository _productRepository;
    private IOrderRepository _orderRepository;
    private IWarehouseRepository _warehouseRepository;
    private IProductWarehouseRepository _productWarehouseRepository;

    public WarehouseService(IProductRepository productRepository, IOrderRepository orderRepository, IWarehouseRepository warehouseRepository, IProductWarehouseRepository productWarehouseRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _warehouseRepository = warehouseRepository;
        _productWarehouseRepository = productWarehouseRepository;
    }

    public async Task<bool> IsProductExists(int idProduct)
    {
        var product = await _productRepository.GetProduct(idProduct);
        return product != null;
        
    }

    public async Task<bool> IsWarehouseExists(int idWarehouse)
    {
        var warehouse = await _warehouseRepository.GetWarehouse(idWarehouse);
        return warehouse != null;
    }

    public async Task<bool> IsOrderExists(WarehouseDTO warehouseDto)
    {
        var order = await _orderRepository.GetOrder(warehouseDto);
        return order != null;
    }

    public async Task<bool> IsOrderCompleted(WarehouseDTO warehouseDto)
    {
        var order = await _orderRepository.GetOrder(warehouseDto);
        return order?.FulfilledAt != null;
    }

    public async Task<bool> IsIdOrderExistInProductWarehouse(WarehouseDTO warehouseDto)
    {
        var order = await _orderRepository.GetOrder(warehouseDto);
        var idOrder = order.IdOrder;
        return await _productWarehouseRepository.IsIdOrderExist(idOrder);

    }
}