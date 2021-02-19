using System;
using System.Collections.Generic;
using System.Linq;
using CarSaloonEvidence.Model;
using CarSaloonEvidence.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarSaloonEvidence.Controllers
{
    [ApiController]
    [Route("api/v1/cars")]
    public class CarController : Controller
    {
        private readonly List<Car> _cars = new();
        private readonly IEnumerable<Manufacturer> _manufacturers;

        public CarController(ICarRepository carRepository)
        {
            _manufacturers = Manufacturer.GetManufacturers();
            _ = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            _cars.AddRange(carRepository.GetCars());
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(_cars);
        }

        [HttpGet("manufacturers")]
        public IActionResult GetAllManufacturers()
        {
            return Ok(_manufacturers);
        }

        [HttpGet("names")]
        public IActionResult GetCarsByManufacturerName([FromQuery] string brand)
        {
            return Ok(_cars.Where(car => car.BrandName == brand));
        }

        [HttpGet("manufacturers/{manufacturerId}")]
        public IActionResult GetAllCarsByManufacturerId(int manufacturerId)
        {
            return Ok(_cars.Where(car => car.Manufacturer.Id == manufacturerId));
        }

        [HttpGet("{manufacturerId}/types/{carType}")]
        public IActionResult GetAllCarsTypesByManufacturerIdAndCarType(int manufacturerId, int carType)
        {
            return Ok(_cars.Where(car => car.Manufacturer.Id == manufacturerId && car.CarType == (CarType)carType));
        }

        [HttpGet("{manufacturerId}/types/{carType}/released-in")]
        public IActionResult GetAllCarsTypesByManufacturerIdAndCarTypeReleasedIn(int manufacturerId, int carType, [FromQuery] DateTime releasedIn)
        {
            return Ok(_cars.Where(car => car.Manufacturer.Id == manufacturerId && car.CarType == (CarType)carType && car.ReleasedIn >= releasedIn));
        }
    }
}
