using GraphQL;

namespace OrdersLib.Schema
{
    public class OrderSchema : GraphQL.Types.Schema
    {
        public OrderSchema(OrderQuery query, OrderMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}