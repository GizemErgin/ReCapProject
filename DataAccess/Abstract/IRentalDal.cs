using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal: IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        List<RentalDetailDto> GetRentalDetailsReturnDateIsNull();
        List<RentalDetailDto> GetRentalDetailsByCarId(int carId);
        List<RentalDetailDto> GetRentalDetailsByCustomerId(int customerId);
        bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate);
    }
}
