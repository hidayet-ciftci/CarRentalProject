using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = ("Admin,Worker"))]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {

                var result = _vehicleService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles = ("Admin,Worker"))]
        [HttpGet("getOneById")]
        public IActionResult getOnebyId(int id)
        {
            try
            {

                var result = _vehicleService.GetOneById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles = ("Admin,Worker"))]
        [HttpPost]
        public IActionResult Add(Vehicle vehicle)
        {
            try
            {

                var result = _vehicleService.Add(vehicle);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles = ("Admin,Worker"))]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {

                var result = _vehicleService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles = ("Admin,Worker"))]
        [HttpPut]
        public IActionResult Update(Vehicle vehicle)
        {
            try
            {

                var result = _vehicleService.Update(vehicle);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost("transactionAdd")]
        public IActionResult AddTransaction(Vehicle vehicle)
        {
            try
            {
                var result = _vehicleService.AddWithTransaction(vehicle);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
