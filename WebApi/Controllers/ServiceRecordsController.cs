using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRecordsController : ControllerBase
    {
        IServiceRecordService _serviceRecordService;
        public ServiceRecordsController(IServiceRecordService serviceRecordService)
        {
            _serviceRecordService = serviceRecordService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                var results = _serviceRecordService.GetAll();
                return Ok(results);
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
                var result = _serviceRecordService.GetOneById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(ServiceRecord serviceRecord)
        {
            try
            {

                var result = _serviceRecordService.Add(serviceRecord);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {

                var result = _serviceRecordService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(ServiceRecord serviceRecord)
        {
            try
            {

                var result = _serviceRecordService.Update(serviceRecord);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpGet("AllServiceDetails")]
        public IActionResult GetAllDetails()
        {
            try
            {
                var result = _serviceRecordService.GetAllServiceDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
