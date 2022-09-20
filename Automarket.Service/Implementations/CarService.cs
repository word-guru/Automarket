using Automarket.DAL.Interface;
using Automarket.Domain.Enum;
using Automarket.Domain.Models;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<Cars>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Cars>();
            try
            {
                var car = await _carRepository.Get(id);

                if(car == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.Status = StatusCode.UserNotFound; 
                    return baseResponse; 
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex) 
            {
                return new BaseResponse<Cars>()
                {
                    Description = $"[GetCar] : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<Cars>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Cars>();
            try
            {
                var car = await _carRepository.GetByName(name);

                if (car == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.Status = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Cars>()
                {
                    Description = $"[GetCarByName] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var car = new Cars()
                {
                    Description = carViewModel.Description,
                    DateCreate = DateTime.Now,
                    Speed = carViewModel.Speed,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    Name = carViewModel.Name,
                    Type = (TypeCar)Convert.ToInt32(carViewModel.Type),
                };

                await _carRepository.Create(car);
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool>()
                {
                    Description = $"[CreateCar] : {ex.Message}"
                };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var car = await _carRepository.Get(id);
                if(car == null)
                {

                    baseResponse.Description = "User not found";
                    baseResponse.Status = StatusCode.UserNotFound;
                    return baseResponse;
                }

                await _carRepository.Delete(car);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<IEnumerable<Cars>>> GetCars()
        {
           var baseResponse = new BaseResponse<IEnumerable<Cars>>();
            try
            {
                var cars = await _carRepository.Select();
                if (cars.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.Status = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.Status = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex) 
            {
                return new BaseResponse<IEnumerable<Cars>>()
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }
        }
    }
}
