using System;
using System.Collections.Generic;
using System.Linq;
using CarSaloonEvidence.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarSaloonEvidence.Controllers
{
    [ApiController]
    [Route("api/v1/cars")]
    public class CarController : Controller
    {
        private readonly List<Car> _cars = new();
        private IEnumerable<Manufacturer> _manufacturers;

        public CarController()
        {
            _manufacturers = Manufacturer.GetManufacturers();
            AddCars();
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(_cars);
        }

        [HttpGet("manufacturers")]
        public IActionResult GetAllCarsManufacturers()
        {
            return Ok(_manufacturers);
        }

        [HttpGet("by-manufacturer-name")]
        public IActionResult GetCarsByManufacturer([FromQuery] string brand)
        {
            return Ok(_cars.Where(car => car.BrandName == brand));
        }

        [HttpGet("{manufacturerId}")]
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

        private void AddCars()
        {
            _cars.Add(new Car
            {
                ModelName = "Scala",
                BrandName = "Skoda",
                CarType = CarType.Hatchback,
                Manufacturer = _manufacturers.Single(m => m.Name == "Skoda"),
                ReleasedIn = new DateTime(2019, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "Octavia",
                BrandName = "Skoda",
                CarType = CarType.LiftBack,
                Manufacturer = _manufacturers.Single(m => m.Name == "Skoda"),
                ReleasedIn = new DateTime(2010, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "Octavia",
                BrandName = "Skoda",
                CarType = CarType.Wagon,
                Manufacturer = _manufacturers.Single(m => m.Name == "Skoda"),
                ReleasedIn = new DateTime(2015, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "Octavia",
                BrandName = "Skoda",
                CarType = CarType.Wagon,
                Manufacturer = _manufacturers.Single(m => m.Name == "Skoda"),
                ReleasedIn = new DateTime(2016, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "i30",
                BrandName = "Hyundai",
                CarType = CarType.Wagon,
                Manufacturer = _manufacturers.Single(m => m.Name == "Hyundai"),
                ReleasedIn = new DateTime(2018, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "i20",
                BrandName = "Hyundai",
                CarType = CarType.Hatchback,
                Manufacturer = _manufacturers.Single(m => m.Name == "Hyundai"),
                ReleasedIn = new DateTime(2017, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "i10",
                BrandName = "Hyundai",
                CarType = CarType.Sedan,
                Manufacturer = _manufacturers.Single(m => m.Name == "Hyundai"),
                ReleasedIn = new DateTime(2018, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "Ceed",
                BrandName = "Kia",
                CarType = CarType.LiftBack,
                Manufacturer = _manufacturers.Single(m => m.Name == "Kia"),
                ReleasedIn = new DateTime(2013, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "Ceed",
                BrandName = "Kia",
                CarType = CarType.Wagon,
                Manufacturer = _manufacturers.Single(m => m.Name == "Kia"),
                ReleasedIn = new DateTime(2014, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "ProCeed",
                BrandName = "Kia",
                CarType = CarType.Sedan,
                Manufacturer = _manufacturers.Single(m => m.Name == "Kia"),
                ReleasedIn = new DateTime(2011, 1, 1)
            });

            _cars.Add(new Car
            {
                ModelName = "Ram",
                BrandName = "Dodge",
                CarType = CarType.PickUp,
                Manufacturer = _manufacturers.Single(m => m.Name == "Dodge"),
                ReleasedIn = new DateTime(2020, 1, 1)
            });
        }
    }
}
