using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserManager
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
