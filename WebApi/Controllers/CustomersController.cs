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
            List<Customer> customers=_customerService.GetAll().ToList();
            return Ok(customers);
        }
        [HttpGet("getOneById")]
        public IActionResult getOnebyId(int id)
        {
            Customer customer = _customerService.GetOneById(id);
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok();
        }
    }
}
