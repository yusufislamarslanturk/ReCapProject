using Business.Abstract;
using Business.Constans;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Utilities.Business;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelperService;


        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;

        }


       
        public IResult Add(IFormFile file, CarImages carImage)
        {

            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.ImagesPath);
            carImage.ImageDate = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);

        }

        public IResult Delete(CarImages carImage)
        {
           
            _fileHelperService.Delete(PathConstants.ImagesPath + carImage.ImagePath);
 
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(i => i.CarImageId == id), Messages.ImagesListedById);

        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.ImagesPath + carImage.ImagePath,
                PathConstants.ImagesPath);
    
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }
        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(), Messages.ImagesListedById);
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == id), Messages.ImagesListedById);
        }

        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();

        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.CarImageAlreadyHave);
            }
            return new SuccessResult();

        }
        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImages = new List<CarImages>();

            carImages.Add(new CarImages { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });

            return new SuccessDataResult<List<CarImages>>(carImages);
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            throw new NotImplementedException();
        }
    }

}

