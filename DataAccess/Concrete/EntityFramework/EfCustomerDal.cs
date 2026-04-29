using Core.DataAccess.EfRepositoryContext;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                             join v in context.Vehicles
                             on c.Id equals v.CustomerId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.Id,FirstName = c.FirstName, LastName = c.LastName,
                                 VehicleId = v.Id,Brand = v.Brand , Color = v.Color, Plate = v.Plate, VIN_Number= v.VIN_Number
                             };
                return result.ToList();
            }
        }
    }
}
