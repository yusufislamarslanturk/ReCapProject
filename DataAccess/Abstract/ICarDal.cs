using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
        List<CarDetailDto> GetCarDetailByCarId(int carId);
        List<CarDetailDto> GetCarDetailByBrandId(int brandId);
        List<CarDetailDto> GetCarDetailByColorId(int colorId);
        List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId);
    }
}
