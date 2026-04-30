using Core.DataAccess.EfRepositoryContext;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {

        public List<OperationClaim> GetClaims(User user)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from uoc in context.UserOperationClaims
                             join oc in context.OperationClaims
                             on uoc.OperationClaimId equals oc.Id
                             where uoc.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = oc.Id,
                                 Name = oc.Name
                             };
                return result.ToList();
            }
        }
        public void AddClaim(int userId, int roleId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var newClaim = new UserOperationClaim
                {
                    UserId = userId,
                    OperationClaimId = roleId,
                };

                context.UserOperationClaims.Add(newClaim);
                context.SaveChanges();
            }
        }
    }
}
