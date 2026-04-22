using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<User> users = _userService.GetAll().ToList();
            return Ok(users);
        }
        [HttpGet("getOneById")]
        public IActionResult getOnebyId(int id)
        {
            User user = _userService.GetOneById(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok();
        }
    }
}
