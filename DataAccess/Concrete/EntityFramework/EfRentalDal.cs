﻿using Core.DataAccess.EntityFramework;
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
                             select new RentalDetailDto
                             {
                               Id=r.Id,
                               CarId=r.CarId,
                               BrandName = b.BrandName,
                               CompanyName = cu.CompanyName,
                               Decription = c.Description,
                               ModelYear = c.ModelYear
                               
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
                             where r.CarId==carId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear

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
                             where r.CustomerId==customerId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear

                             };

                return result.ToList();
            }
        }
    }
}