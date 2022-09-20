using Automarket.DAL.Interface;
using Automarket.Domain.Enum;
using Automarket.Domain.Models;
using Automarket.Domain.Response;
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
