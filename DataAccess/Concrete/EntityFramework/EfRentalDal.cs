using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarsDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from r in context.rentals
                             join c in context.cars
                             on r.CarId equals c.CarId
                             join ct in context.customers
                             on r.CustomerId equals ct.CustomerId
                             join u in context.users
                             on ct.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = ct.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
