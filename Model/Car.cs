using System;

namespace CarSaloonEvidence.Model
{
    public class Car
    {
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public CarType CarType { get; set; }
        public DateTime ReleasedIn { get; set; }
    }
}
