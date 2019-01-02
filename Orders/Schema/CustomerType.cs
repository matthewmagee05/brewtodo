using GraphQL.Types;
using Orders.Models;

namespace Orders.Schema
{
    public class CustomerType: ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);
            Field(n => n.Name);
        }
    }
}