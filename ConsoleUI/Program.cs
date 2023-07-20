using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //carsMethod();
            //AddRental();
            //DetailTest();
          

        }

        private static void carsMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "---" + car.BrandName);
                }
            }
            else
                Console.WriteLine(result.Message);
        }
        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                RentalId = 2,
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1)
            });
        }
        private static void DetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka : " + car.CarName + "-" + car.BrandName + "  " + "Renk : " + car.ColorName + "  " + "Fiyat : " + car.DailyPrice);
            }
        }
    }
}
