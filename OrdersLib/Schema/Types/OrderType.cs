using GraphQL.Types;
using OrdersLib.Models;
using OrdersLib.Services;
using System;

namespace OrdersLib.Schema.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(ICustomerService customer)
        {
            Field<int>(o => o.Id);
            Field<string>(o => o.Name);
            Field<string>(o => o.Description);
            Field<DateTime>(o => o.Created);
            Field<CustomerType>("customer",
                resolve: context => customer.Get(context.Source.CustomerId));
        }
    }
}