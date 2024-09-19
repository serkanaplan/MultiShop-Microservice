using Cargo.Core.Dtos.CargoOperationDtos;
using Cargo.Core.Entities;
using Cargo.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController(ICargoOperationService CargoOperationService) : ControllerBase
{
    private readonly ICargoOperationService _CargoOperationService = CargoOperationService;

    [HttpGet]
    public IActionResult CargoOperationList()
    {
        var values = _CargoOperationService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        CargoOperation CargoOperation = new()
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate
        };
        _CargoOperationService.TInsert(CargoOperation);
        return Ok("Kargo İşlemi Başarıyla Oluşturuldu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoOperation(int id)
    {
        _CargoOperationService.TDelete(id);
        return Ok("Kargo İşlemi Başarıyla Silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoOperationById(int id)
    {
        var values = _CargoOperationService.TGetById(id);
        return Ok(values);
    }

    [HttpPut]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        CargoOperation CargoOperation = new()
        {
            Barcode = updateCargoOperationDto.Barcode,
            CargoOperationId = updateCargoOperationDto.CargoOperationId,
            Description = updateCargoOperationDto.Description,
            OperationDate = updateCargoOperationDto.OperationDate
        };
        _CargoOperationService.TUpdate(CargoOperation);
        return Ok("Kargo İşlemi Başarıyla Güncellendi");
    }
}
