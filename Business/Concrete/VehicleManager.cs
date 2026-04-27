using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        public IResult Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
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
            _vehicleDal.Delete(id);
            return new SuccessResult(Messages.ApiDeleted);
        }

        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(),Messages.ApiListed);
        }

        public IDataResult<Vehicle> GetOneById(int vehicleId)
        {
            return new SuccessDataResult<Vehicle>(_vehicleDal.GetOne(v => v.VehicleId == vehicleId),Messages.ApiListed);
        }

        public IResult Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            return new SuccessResult(Messages.ApiUpdated);
        }
        private IResult checkCustomerNotExist(int id)
        {
            var entityCheck = _vehicleDal.GetOne(v => v.VehicleId == id);
            if (entityCheck is null)
            {
                return new ErrorResult("Boyle bir customer yok");
            }
            else return new SuccessResult();
        }
    }
}
