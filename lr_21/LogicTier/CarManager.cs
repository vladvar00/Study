using DataTier;
using System.Collections.Generic;
using System.Linq;

namespace LogicTier
{
    public class CarManager
    {
        public List<CarVM> Cars { get; }
        public string Title => "Автосалон — Учет автомобилей";

        public CarManager(string path)
        {
            Cars = DataRepository.GetCars(path)
                .Select(c => new CarVM(c)).ToList();
        }

        // Общая стоимость всех авто
        public decimal TotalStockValue => Cars.Sum(c => c.Price);

        // Средняя цена по маркам
        public List<string> AveragePriceByBrand => Cars
            .GroupBy(c => c.Brand)
            .Select(g => $"{g.Key}: {g.Average(c => c.Price):N0} руб.")
            .ToList();
    }
}