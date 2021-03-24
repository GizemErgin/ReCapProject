using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;


        public InMemoryCarDal()
        {

            _cars = new List<Car>
            {
                new Car{ Id=1, BrandId=1, ColorId=1,  DailyPrice=250, ModelYear=2019, Description="Dizel, Otomatik Vites" },
                new Car{ Id=2, BrandId=2, ColorId=2,  DailyPrice=350, ModelYear=2018, Description="Benzin, Manuel Vites" },
                new Car{ Id=3, BrandId=3, ColorId=1,  DailyPrice=280, ModelYear=2017, Description="Dizel, Manuel Vİtes" },
                new Car{ Id=4, BrandId=4, ColorId=3,  DailyPrice=450, ModelYear=2020, Description="Benzin, Otomatik Vites" },
                new Car{ Id=5, BrandId=2, ColorId=1,  DailyPrice=400, ModelYear=2018, Description="Benzin, Yarı Otomatik Vites" },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Eklendi: " + car.BrandId);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            Console.WriteLine("Silindi: " + carToDelete.BrandId);
            _cars.Remove(carToDelete);


        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            Console.WriteLine("Güncellendi: " + carToUpdate.BrandId);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByID(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            throw new NotImplementedException();
        }


        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
