using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly JwtHelper _jwtHelper;

        public AuthManager(IUserDal userDal,JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
            _userDal = userDal;
        }
        public IResult Register(RegisterDto registerDto)
        {
            var existing = _userDal.GetOne(u => u.Email == registerDto.Email);
            if (existing != null)
            {
                return new ErrorResult("bu email zaten var");
            }
            var passwordHash = HashHelper.HashPassword(registerDto.Password);

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PhoneNumber = registerDto.PhoneNumber,
                //RoleId = 2,
                Status = true,
                CreatedTime = DateTime.UtcNow
            };
            _userDal.Add(user);
            return new SuccessResult("Succesfully Registered");
        }
        public IDataResult<string> Login(LoginDto loginDto)
        {
            var user = _userDal.GetOne(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return new ErrorDataResult<string>("Email ya da sifre hatali");
            }
            bool isValid = HashHelper.VerifyPassword(loginDto.Password, user.PasswordHash);
            if (!isValid)
            {
                return new ErrorDataResult<string>("Email ya da sifre hatali");
            }
            var token = _jwtHelper.CreateToken(user);
            return new SuccessDataResult<string>(token, "Giris basarili");
        }
    }
}
