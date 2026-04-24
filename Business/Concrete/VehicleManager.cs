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
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        public void Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetAll();
        }

        public Vehicle GetOneById(int vehicleId)
        {
            return _vehicleDal.GetOne(v => v.VehicleId == vehicleId);
        }

        public void Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
        }
    }
}
