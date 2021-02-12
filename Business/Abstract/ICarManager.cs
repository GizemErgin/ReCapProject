using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<List<Car>> CarByDailyPrice(decimal min, decimal max);
        IResult Delete(Car car);
        IResult Add(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<Car>> GetAllCarsIsNotNull();

    }
}
