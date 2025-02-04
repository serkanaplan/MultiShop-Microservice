﻿using Catalog.Dtos.ContactDtos;

namespace Catalog.Services.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GettAllContactAsync();
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task UpdateContactAsync(UpdateContactDto updateContactDto);
    Task DeleteContactAsync(string id);
    Task<GetByIdContactDto> GetByIdContactAsync(string id);
}
