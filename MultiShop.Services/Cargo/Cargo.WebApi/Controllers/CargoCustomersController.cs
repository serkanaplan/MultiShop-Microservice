using Cargo.Core.Dtos.CargoCustomerDtos;
using Cargo.Core.Entities;
using Cargo.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController(ICargoCustomerService cargoCustomerService) : ControllerBase
{
    private readonly ICargoCustomerService _cargoCustomerService = cargoCustomerService;

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        var values = _cargoCustomerService.TGetAll();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCustomerById(int id)
    {
        var value = _cargoCustomerService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new()
        {
            Address = createCargoCustomerDto.Address,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Email = createCargoCustomerDto.Email,
            Name = createCargoCustomerDto.Name,
            Phone = createCargoCustomerDto.Phone,
            Surname = createCargoCustomerDto.Surname,
            UserCustomerId = createCargoCustomerDto.UserCustomerId
        };
        _cargoCustomerService.TInsert(cargoCustomer);
        return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _cargoCustomerService.TDelete(id);
        return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
    }

    [HttpPut]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new()
        {
            Address = updateCargoCustomerDto.Address,
            CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
            City = updateCargoCustomerDto.City,
            District = updateCargoCustomerDto.District,
            Email = updateCargoCustomerDto.Email,
            Name = updateCargoCustomerDto.Name,
            Phone = updateCargoCustomerDto.Phone,
            Surname = updateCargoCustomerDto.Surname,
            UserCustomerId = updateCargoCustomerDto.UserCustomerId
        };
        _cargoCustomerService.TUpdate(cargoCustomer);
        return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı");
    }

    [HttpGet("GetCargoCustomerById")]
    public IActionResult GetCargoCustomerById(string id)
    {
        return Ok(_cargoCustomerService.TGetCargoCustomerById(id));
    }
}
