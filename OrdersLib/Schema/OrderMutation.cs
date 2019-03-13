using GraphQL.Types;
using OrdersLib.Models;
using OrdersLib.Schema.Types;
using OrdersLib.Services;
using System;

namespace OrdersLib.Schema
{
    public class OrderMutation : ObjectGraphType
    {
        private Random rnd = new Random();

        public OrderMutation(IOrderService orders)
        {
            Name = "Mutation";
            Field<OrderType>("createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>> { Name = "order" }),
                resolve: context =>
               {
                   var orderInput = context.GetArgument<OrderCreateInput>("order");
                   var id = rnd.Next();
                   var order = new Order()
                   {
                       Id = id,
                       Name = orderInput.Name,
                       CustomerId = orderInput.CustomerId,
                   };
                   return orders.Add(order);
               });
        }
    }
}