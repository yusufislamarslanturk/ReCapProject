using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryProductDal()
        {
            //veriler
            _cars = new List<Car> {
          

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //Car carToDelete = _cars.SingleOrDefault(c => c.id == car.id);
            //_cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null, string carsListed = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //Car carToUpdate = _cars.SingleOrDefault(c => c.id == car.id);
            //carToUpdate.ColorId = car.ColorId;
            //carToUpdate.BrandId = car.BrandId;
            //carToUpdate.DailyPrice = car.DailyPrice;
            //carToUpdate.Description= car.Description;
        }
    }
}
