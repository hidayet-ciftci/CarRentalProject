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
            List<ServiceRecord> serviceRecords = _serviceRecordService.GetAll().ToList();
            return Ok(serviceRecords);
        }
        [HttpGet("getOneById")]
        public IActionResult getOnebyId(int id)
        {
            ServiceRecord serviceRecord = _serviceRecordService.GetOneById(id);
            return Ok(serviceRecord);
        }
        [HttpPost]
        public IActionResult Add(ServiceRecord serviceRecord)
        {
            _serviceRecordService.Add(serviceRecord);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(ServiceRecord serviceRecord)
        {
            _serviceRecordService.Delete(serviceRecord);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ServiceRecord serviceRecord)
        {
            _serviceRecordService.Update(serviceRecord);
            return Ok();
        }
    }
}
