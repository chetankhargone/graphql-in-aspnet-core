using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersLib.Models
{
    public class Customer
    {
        public Customer(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
    }
}
