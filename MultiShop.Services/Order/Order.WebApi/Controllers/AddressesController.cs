using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.CQRS.Commands.AddressCommands;
using Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler) : ControllerBase
{
    private readonly GetAddressQueryHandler _getAddressQueryHandler = getAddressQueryHandler;
    private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
    private readonly CreateAddressCommandHandler _createAddressCommandHandler = createAddressCommandHandler;
    private readonly UpdateAddressCommandHandler _updateAddressCommandHandler = updateAddressCommandHandler;
    private readonly RemoveAddressCommandHandler _removeAddressCommandHandler = removeAddressCommandHandler;

    [HttpGet]
    public async Task<IActionResult> AddressList()
    {
        var values = await _getAddressQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
    {
        await _createAddressCommandHandler.Handle(command);
        return Ok("Adres bilgisi başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
    {
        await _updateAddressCommandHandler.Handle(command);
        return Ok("Adres bilgisi başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAddress(int id)
    {
        await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
        return Ok("Adres başarıyla silindi");
    }
}
