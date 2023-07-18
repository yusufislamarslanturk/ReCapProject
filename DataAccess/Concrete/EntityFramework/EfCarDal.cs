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
    public class EfCarDal :EfEntityRepositoryBase<Car,CarsDBContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from c in context.cars
                             join b in context.brands
                             on c.BrandId equals b.BrandId
                             join clr in context.colors on c.ColorId equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = clr.ColorName,
                                 CarName =c.CarName,
                                 Description=c.Description
                                 
                             };
                return result.ToList();
            }


        }

    }
}
