using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(ServiceRecord serviceRecord)
        {
            _serviceRecordDal.Add(serviceRecord);
            return new SuccessResult(Messages.ApiAdded);
        }

        public IResult Delete(ServiceRecord serviceRecord)
        {
            _serviceRecordDal.Delete(serviceRecord);
            return new SuccessResult(Messages.ApiDeleted);
        }

        public IDataResult<List<ServiceRecord>> GetAll()
        {
            return new SuccessDataResult<List<ServiceRecord>>(_serviceRecordDal.GetAll(),Messages.ApiListed);
        }

        public IDataResult<ServiceRecord> GetOneById(int ServiceRecordId)
        {
            return new SuccessDataResult<ServiceRecord>(_serviceRecordDal.GetOne(s => s.ServiceRecordId == ServiceRecordId),Messages.ApiListed);
        }

        public IResult Update(ServiceRecord serviceRecord)
        {
            _serviceRecordDal.Update(serviceRecord);
            return new SuccessResult(Messages.ApiUpdated);
        }
    }
}
