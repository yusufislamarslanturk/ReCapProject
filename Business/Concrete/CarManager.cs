using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal carDal)
        {
            _cardal = carDal;
        }


        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }

        public List<Car> GetAllByCategoryId(int id)
        {
            return _cardal.GetAll(p => p.CarId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _cardal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

     
    }
}
