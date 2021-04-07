using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.Models
{
    public class CustomerSession
    {
        private const string CustomerKey = "Customer";

        private ISession session;

        public CustomerSession(ISession sess) => session = sess;

        public Customer GetCustomer() => session.GetObject<Customer>(CustomerKey) ?? new Customer();

        public void SetCustomer(Customer customer) => session.SetObject(CustomerKey, customer);
    }
}
