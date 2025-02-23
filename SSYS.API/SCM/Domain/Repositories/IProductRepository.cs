﻿using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.SCM.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByIdAsync(int id);
    void Update(Product product);
    void Remove(Product product);
}