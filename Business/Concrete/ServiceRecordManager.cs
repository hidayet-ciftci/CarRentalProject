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
    public class ServiceRecordManager : IServiceRecordService
    {
        IServiceRecordDal _serviceRecordDal;

        public ServiceRecordManager(IServiceRecordDal serviceRecordDal)
        {
            _serviceRecordDal = serviceRecordDal;
        }
        public void Add(ServiceRecord serviceRecord)
        {
            _serviceRecordDal.Add(serviceRecord);
        }

        public void Delete(ServiceRecord serviceRecord)
        {
            _serviceRecordDal.Delete(serviceRecord);
        }

        public List<ServiceRecord> GetAllUsers()
        {
            return _serviceRecordDal.GetAll();
        }

        public ServiceRecord GetOneUserById(int ServiceRecordId)
        {
            return _serviceRecordDal.GetOne(s => s.Id == ServiceRecordId);
        }

        public void Update(ServiceRecord serviceRecord)
        {
            _serviceRecordDal.Update(serviceRecord);
        }
    }
}
