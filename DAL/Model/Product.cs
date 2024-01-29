﻿using Microsoft.EntityFrameworkCore;

namespace DAL.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public int Popularity { get; set; } = 0;
    public ICollection<OrderProducts> OrderProducts { get; set; }
    public string ImgPath { get; set; }
    public bool Disabled { get; set; } = false;
    public string Description { get; set; }

}

