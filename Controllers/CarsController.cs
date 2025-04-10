using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lecture5_Gr1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetCars")]
        public List<Car> GetCars(int pageIndex, int elementCount)
        {
            return _carService.GetCars(pageIndex, elementCount);
        }

        [HttpGet("GetAllCars")]
        public List<Car> GetAllCars(int minCreateYear, bool isWhite)
        {
            return _carService.GetAllCars(minCreateYear, isWhite);
        }

        [HttpPost]
        public void AddCar(Car car)
        {
            _carService.AddCar(car);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid id)
        {
            var success = _carService.DeleteCar(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCar(Car car)
        {
            var success = _carService.UpdateCar(car);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
