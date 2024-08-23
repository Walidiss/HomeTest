using GetDinners.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Dinners.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        private Location(string name, string description, double latitude, double longitude)
        {
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
        }

        private static Location CreateNew(string name, string description, double latitude, double longitude)
        {
            return new Location(name, description, latitude, longitude);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Description;
            yield return Latitude;
            yield return Longitude;

        }
    }
}
