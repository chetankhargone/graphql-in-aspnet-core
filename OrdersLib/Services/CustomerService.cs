using Microsoft.EntityFrameworkCore;
using OrdersLib.Db;
using OrdersLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersLib.Services
{
    public interface ICustomerService
    {
        Task<Customer> Add(Customer customer);

        Task<Customer> Get(int customerId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly OrdersContext _dbContext;

        public CustomerService()
        {
            _dbContext = new OrdersContext();
        }
        public async Task<Customer> Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Get(int customerId)
        {
            return await _dbContext.Customers.Where(x => x.Id == customerId).FirstOrDefaultAsync();
        }
    }
}
