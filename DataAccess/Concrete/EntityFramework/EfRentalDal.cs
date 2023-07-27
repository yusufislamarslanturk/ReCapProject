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

    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from r in context.rentals
                             join u in context.users
                                 on r.CustomerId equals u.Id
                             join c in context.cars
                                 on r.CarId equals c.CarId

                             select new RentalDetailDto()
                             {
                                 Description = c.Description,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }

    }}
