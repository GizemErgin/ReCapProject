using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, CarDataContext>, IRentalDal
    {
        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (CarDataContext context = new CarDataContext())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.EstReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.EstReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDataContext context = new CarDataContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             select new RentalDetailDto
                             {
                               Id=r.Id,
                               CarId=r.CarId,
                               BrandName = b.BrandName,
                               CompanyName = cu.CompanyName,
                               Decription = c.Description,
                               ModelYear = c.ModelYear,
                               RentDate = r.RentDate,
                               EstReturnDate = r.EstReturnDate,
                               ReturnDate = r.ReturnDate,
                               DailyPrice = c.DailyPrice,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               CardNameSurname = p.CardNameSurname,
                               CardNumber = p.CardNumber,
                               CardExpiryDate = p.CardExpiryDate,
                               CardCvv = p.CardCvv,
                               TotalPaye = p.TotalPaye
                             };

                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailsByCarId(int carId)
        {
            using (CarDataContext context = new CarDataContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             where r.CarId==carId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye

                             };

                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailsByCustomerId(int customerId)
        {
            using (CarDataContext context = new CarDataContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             where r.CustomerId==customerId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye

                             };

                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailsReturnDateIsNull()
        {
            using (CarDataContext context = new CarDataContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             where r.ReturnDate == null
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye
                             };

                return result.ToList();
            }
        }
    }
}
