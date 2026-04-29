using Core.DataAccess.EfRepositoryContext;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfServiceRecordDal : EfEntityRepositoryBase<ServiceRecord, CarRentalContext>, IServiceRecordDal
    {
        public List<ServiceDetailViewDto> GetAllServiceDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<ServiceDetailViewDto>().ToList();
                
            }
        }
    }
}
