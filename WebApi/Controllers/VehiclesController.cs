using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<Vehicle> vehicles = _vehicleService.GetAll().ToList();
            return Ok(vehicles);
        }
        [HttpGet("getOneById")]
        public IActionResult getOnebyId(int id)
        {
            Vehicle vehicle = _vehicleService.GetOneById(id);
            return Ok(vehicle);
        }
        [HttpPost]
        public IActionResult Add(Vehicle vehicle)
        {
            _vehicleService.Add(vehicle);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Vehicle vehicle)
        {
            _vehicleService.Delete(vehicle);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Vehicle vehicle)
        {
            _vehicleService.Update(vehicle);
            return Ok();
        }
    }
}
