﻿namespace MultiShop.WebUI.DTOs.CatalogDtos.ProductDtos;

public class ResultProductDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }
    public string CategoryId { get; set; }
}
