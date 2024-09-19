using Catalog.Dtos.ContactDtos;
using Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ContactsController(IContactService ContactService) : ControllerBase
{
    private readonly IContactService _ContactService = ContactService;

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var values = await _ContactService.GettAllContactAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(string id)
    {
        var values = await _ContactService.GetByIdContactAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        await _ContactService.CreateContactAsync(createContactDto);
        return Ok("Mesaj başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(string id)
    {
        await _ContactService.DeleteContactAsync(id);
        return Ok("Mesaj başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
    {
        await _ContactService.UpdateContactAsync(updateContactDto);
        return Ok("Mesaj başarıyla güncellendi");
    }
}
