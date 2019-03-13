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
    public interface IOrderService
    {
        Task<Order> Add(Order order);

        Task<IEnumerable<Order>> Get();

        Task<Order> Get(int orderId);

        Task<Order> Put(Order order);

        Task<bool> Delete(int orderId);
    }

    public class OrderService : IOrderService
    {
        private readonly OrdersContext _dbContext;

        public OrderService()
        {
            _dbContext = new OrdersContext();
        }

        public async Task<Order> Add(Order order)
        {
            try
            {
                order.Created = DateTime.Now;
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message ?? ex.InnerException.Message);
            }
        }

        public async Task<bool> Delete(int orderId)
        {
            var order = await _dbContext.Orders.Where(x => x.Id == orderId).ToListAsync<Order>();
            _dbContext.RemoveRange(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _dbContext.Orders.ToListAsync<Order>();
        }

        public async Task<Order> Get(int orderId)
        {
            try
            {
                return await _dbContext.Orders.Where(x => x.Id == orderId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message ?? ex.InnerException.Message);
            }
        }

        public async Task<Order> Put(Order order)
        {
            try
            {
                var dbOrder = await _dbContext.Orders.Where(x => x.Id == order.Id).FirstOrDefaultAsync();
                dbOrder = order;
                _dbContext.Update<Order>(dbOrder);
                await _dbContext.SaveChangesAsync();

                return dbOrder;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message ?? ex.InnerException.Message); ;
            }
        }
    }
}
