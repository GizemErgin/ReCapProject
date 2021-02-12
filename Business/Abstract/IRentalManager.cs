﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IDataResult<List<Rental>> GetByCustomerId(int id);
        IDataResult<List<Rental>> GetByCarId(int id);
        IResult Delete(Rental rental);
        IResult Rent(int carId, int customerId);
        IResult Update(Rental rental);

    }
}
