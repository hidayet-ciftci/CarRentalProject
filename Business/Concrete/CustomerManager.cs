using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
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

        private readonly IValidator<Customer> _validator;

        public CustomerManager(ICustomerDal customerDal, IValidator<Customer> validator)
        {
            _customerDal = customerDal;
            _validator = validator;
        }
        public void Add(Customer customer)
        {
            var result = _validator.Validate(customer);
            if (!result.IsValid)
            {
                var messages = string.Join(", ", result.Errors.Select(x => x.ErrorMessage));
                throw new Exception(messages);
            }
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetOneById(int customerId)
        {
            return _customerDal.GetOne(c => c.CustomerId == customerId);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
