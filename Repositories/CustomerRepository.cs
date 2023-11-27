using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseMVC.Infrastructure.Repositories 
{
    public class CustomerRepository : ICustomerRepository
    {
        public IQueryable<Customer> GetAllActiveCustomers()
        {
                throw new NotImplementedException();
        }

        public CustomerRepository getCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}