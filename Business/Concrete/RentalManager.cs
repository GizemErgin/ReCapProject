using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalManager.Get")]
        //[SecuredOperation("admin,rental.admin")]
        public IResult Rent(int carId, int customerId)
        {
            //var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            //if (result.Count > 0)
            //{
            //    return new ErrorResult(Messages.RentalReturnDateIsNull);
            //}
            var result = _rentalDal.Get(r=> r.CarId==carId && r.ReturnDate==null);
            if (result != null)
            {
                return new ErrorResult(Messages.RentalReturnDateIsNull);
            }
            _rentalDal.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            
            return new SuccessResult(Messages.RentalAdded);
        }

        [TransactionScopeAspect]
        [SecuredOperation("admin,rental.admin")]
        public IResult Deliver(int rentId, DateTime dateTime)
        {
            var result = _rentalDal.Get(r=> r.Id==rentId && r.ReturnDate == null);
            if (result != null)
            {
                result.ReturnDate = dateTime;
                _rentalDal.Update(result);
                return new SuccessResult(Messages.RentalDelivered); 
            }
            return new ErrorResult(Messages.RentalReturnDateIsNotNull);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalManager.Get")]
        [SecuredOperation("admin,rental.admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsReturnDateIsNull()
        {
            
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsReturnDateIsNull());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsByCarId(carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsByCustomerId(customerId));
        }


    }
}
