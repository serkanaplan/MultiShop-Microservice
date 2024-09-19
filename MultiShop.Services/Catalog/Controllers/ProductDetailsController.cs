using Catalog.Dtos.ProductDetailDtos;
using Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController(IProductDetailService ProductDetailService) : ControllerBase
{
    private readonly IProductDetailService _productDetailService = ProductDetailService;

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await _productDetailService.GettAllProductDetailAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var values = await _productDetailService.GetByIdProductDetailAsync(id);
        return Ok(values);
    }

    [HttpGet("GetProductDetailByProductId/{id}")]
    public async Task<IActionResult> GetProductDetailByProductId(string id)
    {
        var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
        return Ok("Ürün detayı başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return Ok("Ürün detayı başarıyla güncellendi");
    }
}
