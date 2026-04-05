using DataTier;

namespace LogicTier
{
    public class CarVM
    {
        private Car _car;
        public CarVM(Car c) => _car = c;

        public string FullTitle => $"{_car.Brand} {_car.Model} ({_car.Year} г.)";
        public string Brand => _car.Brand;
        public decimal Price => _car.Price;
    }
}