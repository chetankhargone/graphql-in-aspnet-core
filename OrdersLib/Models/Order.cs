using System;

namespace OrdersLib.Models
{
    public class Order
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public virtual Customer Customer { get; set; }
    }
}