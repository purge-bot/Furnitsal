using Furnitsal.Models.Counterparty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models
{
    class Order
    {
        public Customer Customer { get; private set; }
        public Sender Sender { get; private set; }

        public Order(Customer customer, Sender sender)
        {
            Customer = customer;
            Sender = sender;
        }
    }
}
