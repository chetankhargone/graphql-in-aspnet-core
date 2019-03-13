using GraphQL.Types;
using OrdersLib.Schema.Types;
using OrdersLib.Services;

namespace OrdersLib.Schema
{
    public class OrderQuery : ObjectGraphType<object>
    {
        public OrderQuery(IOrderService order)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>("orders",
                resolve: context => order.Get());
        }
    }
}