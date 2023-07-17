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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                return filter == null
              ? context.Set<Car>().ToList()
              : context.Set<Car>().Where(filter).ToList();

            }
        }

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

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
