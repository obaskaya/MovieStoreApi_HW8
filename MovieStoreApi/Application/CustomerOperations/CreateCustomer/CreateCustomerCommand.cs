using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Application.CustomerOperations.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle()
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Name == Model.Name && c.Surname == Model.Surname);
            if (customer is not null)
                throw new InvalidOperationException("Customer already exist in database");

            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}

