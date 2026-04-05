using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace DataTier
{
    public static class DataRepository
    {
        public static List<Car> GetCars(string filePath)
        {
            var list = new List<Car>();
            if (!File.Exists(filePath)) return list;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    list.Add(new Car
                    {
                        Brand = parts[0].Trim(),
                        Model = parts[1].Trim(),
                        Year = int.Parse(parts[2].Trim()),
                        Price = decimal.Parse(parts[3].Trim(), CultureInfo.InvariantCulture)
                    });
                }
            }
            return list;
        }
    }
}