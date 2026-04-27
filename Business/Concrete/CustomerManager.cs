using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
        public IResult Add(Customer customer)
        {
            var result = _validator.Validate(customer);
            if (!result.IsValid)
            {
                var messages = string.Join(", ", result.Errors.Select(x => x.ErrorMessage));
                return new ErrorResult(messages);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ApiAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.ApiDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.ApiListed);
        }

        public IDataResult<Customer> GetOneById(int customerId)
        {
            var entity = _customerDal.GetOne(c => c.CustomerId == customerId);
            if (entity is null)
            {
                return new ErrorDataResult<Customer>(entity,Messages.NotFound);
            }   
            return new SuccessDataResult<Customer>(entity,Messages.ApiListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.ApiUpdated);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(),Messages.ApiListed);
        }
    }
}
