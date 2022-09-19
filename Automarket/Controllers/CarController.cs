using Automarket.DAL.Interface;
using Automarket.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarsAsync()
        {
            var responseAll = await _carRepository.Select();
            var responseName = await _carRepository.GetByName("BMW X5");
            var responseId = await _carRepository.Get(3);
            var car = new Cars()
            {
                Name = "Vaz 2114",
                Model = "VAZ",
                Speed = 130,
                Price = 150000,
                Description = "Ваз",
                DateCreate = DateTime.Now
            };
            await _carRepository.Create(car);
            await _carRepository.Delete(car);

            return View(responseAll);
        }
    }
}
