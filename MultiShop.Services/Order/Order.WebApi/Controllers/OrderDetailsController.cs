using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler) : ControllerBase
{
    private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
    private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
    private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;

    [HttpGet]
    public async Task<IActionResult> OrderDetailList()
    {
        var values = await _getOrderDetailQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
    {
        await _createOrderDetailCommandHandler.Handle(command);
        return Ok("Sipariş detayı başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveOrderDetail(int id)
    {
        await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
        return Ok("Sipariş detayı başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        await _updateOrderDetailCommandHandler.Handle(command);
        return Ok("Sipariş detayı başarıyla güncellendi");
    }
}