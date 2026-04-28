using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
            //business Codes
            IResult result = BusinessRules.Run(checkCustomerExist(customer.Id), checkPhoneNumExist(customer.PhoneNumber),checkEmailExist(customer.Email), checkCustomerNum());
           if (result != null)
            {
                return result;
            }
            var ValidateResult = _validator.Validate(customer);
            if (!ValidateResult.IsValid)
            {
                var messages = string.Join(", ", ValidateResult.Errors.Select(x => x.ErrorMessage));
                return new ErrorResult(messages);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ApiAdded);
        }

        public IResult Delete(int id)
        {
            //business Codes
            IResult result = BusinessRules.Run(checkCustomerNotExist(id));
            if (result != null)
            {
                return result;
            }
            _customerDal.Delete(id);
            return new SuccessResult(Messages.ApiDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.ApiListed);
        }

        public IDataResult<Customer> GetOneById(int customerId)
        {
            var entity = _customerDal.GetOne(c => c.Id == customerId);
            if (entity is null)
            {
                return new ErrorDataResult<Customer>(entity, Messages.NotFound);
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
        private IResult checkCustomerNum()
        {
            var customerNum = _customerDal.GetAll().Count;
            if (customerNum > 15)
            {
                return new ErrorResult("15 limite ulasildi");
            }
            else return new SuccessResult();
        }
        private IResult checkCustomerExist(int id)
        {
            var entityCheck = _customerDal.GetOne(c=>c.Id ==id);
            if (entityCheck is null)
            {
                return new SuccessResult();
            }
            else return new ErrorResult("Boyle bir customer Id zaten var");
        }
        private IResult checkEmailExist(string email)
        {
            var emailCheck = _customerDal.GetOne(c => c.Email == email);
            if (emailCheck is null)
            {
                return new SuccessResult();
            }
            else return new ErrorResult("Boyle bir customer Email zaten var");
        }
        private IResult checkPhoneNumExist(string phoneNum)
        {
            var phoneCheck = _customerDal.GetOne(c => c.PhoneNumber == phoneNum);
            if (phoneCheck is null)
            {
                return new SuccessResult();
            }
            else return new ErrorResult("Boyle bir customer telefon numarası zaten var");
        }
        private IResult checkCustomerNotExist(int id)
        {
            var entityCheck = _customerDal.GetOne(c => c.Id == id);
            if (entityCheck is null)
            {
                return new ErrorResult("Boyle bir customer yok");
            }
            else return new SuccessResult();
        }
    }
}
