using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.Write(item.CarName + "-");
                Console.Write(item.BrandName+"-");
                Console.Write(item.ColorName+"-");
                Console.Write(item.DailyPrice+"-");
                Console.WriteLine(item.Description);
                Console.WriteLine();
            }
           
        }
    }
}
