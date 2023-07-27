using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {


        IDataResult<List<CarImages>> GetImagesByCarId(int id);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int id);
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);

    }

}
