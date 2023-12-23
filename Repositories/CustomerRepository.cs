using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RestApi.Models;
using RestApi.Repositories;

namespace WarehouseMVC.Infrastructure.Repositories 
{
    public class CustomerRepository : ICustomerRepository
    {
        public IQueryable<Customer> GetAllActiveCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
