using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsDBContext>, ICarDal
    {
       

            public List<CarDetailDto> GetCarDetail()
            {
                using (CarsDBContext context = new CarsDBContext())
                {
                    var result = from car in context.cars
                                 join b in context.brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.colors
                                 on car.ColorId equals c.ColorId
                                 select new CarDetailDto
                                 {
                                     CarId = car.CarId,
                                     BrandId = b.BrandId,
                                     ColorId = c.ColorId,
                                     BrandName = b.BrandName,
                                     ColorName = c.ColorName,
                                     ModelName = car.Model,
                                     DailyPrice = car.DailyPrice,
                                     Description = car.Description,
                                     ModelYear = car.ModelYear,
                                     ImagePath = (from ci in context.carImages where ci.CarId == car.CarId select ci.ImagePath).FirstOrDefault()
                                 };

                    return result.ToList();
                }
            }

            public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
            {
                using (CarsDBContext context = new CarsDBContext())
                {
                    var result = from car in context.cars
                                 join b in context.brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.colors
                                 on car.ColorId equals c.ColorId
                                 where b.BrandId == brandId
                                 select new CarDetailDto
                                 {
                                     CarId = car.CarId,
                                     BrandId = b.BrandId,
                                     ColorId = c.ColorId,
                                     BrandName = b.BrandName,
                                     ColorName = c.ColorName,
                                     ModelName = car.Model,
                                     Description = car.Description,
                                     DailyPrice = car.DailyPrice,
                                     ModelYear = car.ModelYear,
                                     ImagePath = (from ci in context.carImages where car.CarId == ci.CarId select ci.ImagePath).FirstOrDefault()
                                 };
                    return result.ToList();
                }
            }

            public List<CarDetailDto> GetCarDetailByCarId(int carId)
            {
                using (CarsDBContext context = new CarsDBContext())
                {
                    var result = from car in context.cars
                                 join b in context.brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.colors
                                 on car.ColorId equals c.ColorId
                                 where car.CarId == carId
                                 select new CarDetailDto
                                 {
                                     CarId = car.CarId,
                                     BrandId = b.BrandId,
                                     ColorId = c.ColorId,
                                     BrandName = b.BrandName,
                                     ColorName = c.ColorName,
                                     ModelName = car.Model,
                                     Description = car.Description,
                                     DailyPrice = car.DailyPrice,
                                     ModelYear = car.ModelYear,
                                     ImagePath = (from ci in context.carImages where car.CarId == ci.CarId select ci.ImagePath).FirstOrDefault()
                                 };
                    return result.ToList();
                }
            }

            public List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId)
            {
                using (CarsDBContext context = new CarsDBContext())
                {
                    var result = from car in context.cars
                                 join b in context.brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.colors
                                 on car.ColorId equals c.ColorId
                                 where c.ColorId == colorId && b.BrandId == brandId
                                 select new CarDetailDto
                                 {
                                     CarId = car.CarId,
                                     BrandId = b.BrandId,
                                     ColorId = c.ColorId,
                                     BrandName = b.BrandName,
                                     ColorName = c.ColorName,
                                     ModelName = car.Model,
                                     Description = car.Description,
                                     DailyPrice = car.DailyPrice,
                                     ModelYear = car.ModelYear,
                                     ImagePath = (from ci in context.carImages where car.CarId == ci.CarId select ci.ImagePath).FirstOrDefault()
                                 };
                    return result.ToList();
                }
            }

            public List<CarDetailDto> GetCarDetailByColorId(int colorId)
            {
                using (CarsDBContext context = new CarsDBContext())
                {
                    var result = from car in context.cars
                                 join b in context.brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.colors
                                 on car.ColorId equals c.ColorId
                                 where c.ColorId == colorId
                                 select new CarDetailDto
                                 {
                                     CarId = car.CarId,
                                     BrandId = b.BrandId,
                                     ColorId = c.ColorId,
                                     BrandName = b.BrandName,
                                     ColorName = c.ColorName,
                                     ModelName = car.Model,
                                     Description = car.Description,
                                     DailyPrice = car.DailyPrice,
                                     ModelYear = car.ModelYear,
                                     ImagePath = (from ci in context.carImages where car.CarId == ci.CarId select ci.ImagePath).FirstOrDefault()
                                 };
                    return result.ToList();
                }
            }
        }
    } 
