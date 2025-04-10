namespace Lecture5_Gr1
{
    public interface ICarService
    {
        public List<Car> GetAllCars(int minCreateYear, bool isWhite);
        public List<Car> GetCars(int pageIndex, int elementCount);    
        public void AddCar(Car car);
        public bool DeleteCar(Guid id);  
        public bool UpdateCar(Car car);
    }
}
