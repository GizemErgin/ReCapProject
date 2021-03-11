using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorManager
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [CacheRemoveAspect("IColorManager.Get")]
        [SecuredOperation("admin,color.admin")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(color.ColorId + " " + color.ColorName + Messages.ColorAdded);
        }

        [SecuredOperation("admin,color.admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheRemoveAspect("IColorManager.Get")]
        [SecuredOperation("admin,color.admin")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        [TransactionScopeAspect]
        public IResult TransactionalTest(Color color)
        {
            _colorDal.Add(color);
            _colorDal.Update(color);
            return null;
        }
    }
}
