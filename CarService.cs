namespace Lecture5_Gr1
{
    public class CarService : ICarService
    {
        private AppDbContext _dbContext;

        public CarService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void AddCar(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public List<Car> GetAllCars(int minCreateYear, bool isWhite)
        {
            var cars = _dbContext.Cars
                .Where(x => x.CreateYear > minCreateYear &&
                            x.IsWhite == isWhite)
                .OrderBy(x => x.CreateYear)
                .ToList();

            return cars;
        }

        public List<Car> GetCars(int pageIndex, int elementCount)
        {
            var cars = _dbContext.Cars.Skip((pageIndex - 1) * elementCount)
                .Take(elementCount).ToList();

            return cars;
        }

        public bool DeleteCar(Guid id)
        {
            var car = _dbContext.Cars.Find(id);
            if (car == null) return false;

            _dbContext.Cars.Remove(car);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateCar(Car car)
        {
            var existingCar = _dbContext.Cars.Find(car.Id);
            if (existingCar == null) return false;

            _dbContext.Entry(existingCar).CurrentValues.SetValues(car);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
