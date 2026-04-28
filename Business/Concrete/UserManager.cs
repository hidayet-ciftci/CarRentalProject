using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
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
            _userDal.Delete(id);
            return new SuccessResult(Messages.ApiDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.ApiListed);
        }

        public IDataResult<User> GetOneById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.GetOne(u => u.Id == userId),Messages.ApiListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.ApiUpdated);
        }

        private IResult checkCustomerNotExist(int id)
        {
            var entityCheck = _userDal.GetOne(u => u.Id== id);
            if (entityCheck is null)
            {
                return new ErrorResult("Boyle bir Service Record yok");
            }
            else return new SuccessResult();
        }
    }
}
