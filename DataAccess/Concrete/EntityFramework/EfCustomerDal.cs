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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarDataContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarDataContext context =new CarDataContext()) 
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Findeks = cu.Findeks,

                             };

                return result.ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetailsById(int customerId)
        {
            using (CarDataContext context = new CarDataContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             where cu.Id ==customerId
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Findeks = cu.Findeks,

                             };

                return result.SingleOrDefault();
            }
        }

        public CustomerDetailDto GetCustomerDetailsByUserId(int userId)
        {
            using (CarDataContext context = new CarDataContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             where cu.UserId == userId
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Findeks = cu.Findeks,

                             };

                return result.SingleOrDefault();
            }
        }
    }
}
