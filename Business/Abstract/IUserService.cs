using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(int id);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetOneById(int userId);
        public IDataResult<List<User>> GetAllWithTransaction();
    }
}
