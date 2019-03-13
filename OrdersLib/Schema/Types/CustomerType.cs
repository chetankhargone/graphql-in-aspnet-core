using GraphQL.Types;
using OrdersLib.Models;

namespace OrdersLib.Schema.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field<int>(x => x.Id);
            Field<string>(x => x.Name);
        }
    }
}