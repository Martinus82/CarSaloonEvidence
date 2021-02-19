using System.Collections.Generic;
using CarSaloonEvidence.Model;

namespace CarSaloonEvidence.Repository.Interfaces
{
    public interface ICarRepository
    {
        public IEnumerable<Car> GetCars();
    }
}