using Catalog.Dtos.SpecialOfferDtos;
using Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SpecialOffersController(ISpecialOfferService SpecialOfferService) : ControllerBase
{
    private readonly ISpecialOfferService _SpecialOfferService = SpecialOfferService;

    [HttpGet]
    public async Task<IActionResult> SpecialOfferList()
    {
        var values = await _SpecialOfferService.GettAllSpecialOfferAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialOfferById(string id)
    {
        var values = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
        return Ok("Özel teklif başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _SpecialOfferService.DeleteSpecialOfferAsync(id);
        return Ok("Özel teklif başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
        return Ok("Özel teklif başarıyla güncellendi");
    }
}
