using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<Customer> GetAllUsers()
        {
            return _customerDal.GetAll();
        }

        public Customer GetOneUserById(int customerId)
        {
            return _customerDal.GetOne(c => c.Id == customerId);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
