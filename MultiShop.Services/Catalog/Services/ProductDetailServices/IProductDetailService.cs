﻿using Catalog.Dtos.ProductDetailDtos;

namespace Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GettAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
}
