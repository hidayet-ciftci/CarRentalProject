using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(int id);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetOneById(int customerId);

        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
    }
}
