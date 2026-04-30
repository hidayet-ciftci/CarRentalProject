using Core.DataAccess.EfRepositoryContext;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVehicelDal : EfEntityRepositoryBase<Vehicle,CarRentalContext>,IVehicleDal
    {
        private readonly CarRentalContext _context;

        public EfVehicelDal(CarRentalContext context)
        {
            _context = context;
        }

        public IResult AddWithTransaction(Vehicle vehicle)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
                transaction.Commit();
                return new SuccessResult("transaction basarili");
            }
            catch (Exception)
            {
                transaction.Rollback();
                return new ErrorResult("transaction basarisiz");
            }
        }
    }
}
