using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerManager
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<CustomerDetailDto> GetCustomerDetailsById(int customerId);
        IDataResult<CustomerDetailDto> GetCustomerDetailsByUserId(int userId);

        IDataResult<Customer> GetByUserId(int userId);
        IDataResult<Customer> GetByCustomerId(int id);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
