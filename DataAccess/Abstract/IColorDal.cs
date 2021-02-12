using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal: IEntityRepository<Entities.Concrete.Color>
    {
    }
}
