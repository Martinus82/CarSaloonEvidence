using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using CarSaloonEvidence.Model;
using CarSaloonEvidence.Repository.Interfaces;

namespace CarSaloonEvidence.Repository
{
    public class JsonFileCarRepository : ICarRepository
    {
        private readonly List<Car> _cars = new();

        public JsonFileCarRepository()
        {
        }

        public IEnumerable<Car> GetCars()
        {
            _cars.AddRange(ReadJsonFileContent());
            return _cars;
        }

        public IEnumerable<Car> ReadJsonFileContent()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string content = File.ReadAllText(path + "\\Repository\\Cars.json");
            var cars = JsonSerializer.Deserialize<List<Car>>(content);
            return cars;
        }
    }
}
