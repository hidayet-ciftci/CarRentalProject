using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                var customers = _customerService.GetAll();
                return Ok(customers);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpGet("getOneById")]
        public IActionResult getOnebyId(int id)
        {
            try
            {
                var customer = _customerService.GetOneById(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            try
            {
                var result = _customerService.Add(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            try
            {
                var result = _customerService.Delete(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            try
            {
                var result = _customerService.Update(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
