using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceRecordService
    {
        void Add(ServiceRecord serviceRecord);
        void Delete(ServiceRecord serviceRecord);
        void Update(ServiceRecord serviceRecord);
        List<ServiceRecord> GetAllUsers();
        ServiceRecord GetOneUserById(int ServiceRecordId);
    }
}
