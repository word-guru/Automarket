﻿using Automarket.DAL.Interface;
using Automarket.Domain.Models;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarsAsync()
        {
            var response = await _carService.GetCars();

            return View(response.Data);
        }
    }
}
