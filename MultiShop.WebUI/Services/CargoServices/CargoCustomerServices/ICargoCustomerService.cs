﻿using MultiShop.WebUI.DTOs.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;

public interface ICargoCustomerService
{
    Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
}
