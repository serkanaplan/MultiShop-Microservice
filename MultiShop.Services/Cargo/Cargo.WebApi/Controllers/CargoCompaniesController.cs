using Cargo.Core.Dtos.CargoCompanyDtos;
using Cargo.Core.Entities;
using Cargo.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController(ICargoCompanyService cargoCompanyService) : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService = cargoCompanyService;

    [HttpGet]
    public IActionResult CargoCompanyList() => Ok( _cargoCompanyService.TGetAll());

    [HttpPost]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        CargoCompany cargoCompany = new() { CargoCompanyName = createCargoCompanyDto.CargoCompanyName };
        _cargoCompanyService.TInsert(cargoCompany);
        return Ok("Kargo Şirketi Başarıyla Oluşturuldu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCompany(int id)
    {
        _cargoCompanyService.TDelete(id);
        return Ok("Kargo Şirketi Başarıyla Silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompanyById(int id) =>Ok(_cargoCompanyService.TGetById(id));

    [HttpPut]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
            CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
        };
        _cargoCompanyService.TUpdate(cargoCompany);
        return Ok("Kargo Şirketi Başarıyla Güncellendi");
    }
}
