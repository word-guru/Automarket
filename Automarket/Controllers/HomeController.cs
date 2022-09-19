using Automarket.DAL;
using Automarket.DAL.Interface;
using Automarket.Domain.Models;
using Automarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Automarket.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
           // _logger = logger;
           _carRepository = carRepository;
          
        }

        public async Task<IActionResult> Index()
        {
            var response = await _carRepository.Select();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}