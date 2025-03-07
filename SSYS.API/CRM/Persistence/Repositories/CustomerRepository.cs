﻿using Microsoft.EntityFrameworkCore;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.CRM.Persistence.Repositories;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Customer>> ListAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public async Task<Customer> FindByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void Remove(Customer customer)
    {
        _context.Customers.Remove(customer);
    }
}