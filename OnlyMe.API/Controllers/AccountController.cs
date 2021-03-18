using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlyMe.DAL.Context;
using OnlyMe.DAL.Entities;
using OnlyMe.DAL.Models;
using OnlyMe.DAL.Models.User;
using OnlyMe.Services.Services.UsersService;

namespace OnlyMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly OnlyMeDBContext _dBContext;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, OnlyMeDBContext dBContext, IMapper mapper)
        {
            _userService = userService;
            _dBContext = dBContext;
            _mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<ResponseVM> Register([FromForm] UserRegisterVM userRegisterVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.Regiser(userRegisterVM);

                    if (result.Succeeded)
                    {
                        return new ResponseVM()
                        {
                            IsSuccess = true,
                            Message = "تم التسجيل بنجاح"
                        };
                    }
                    else
                    {
                        return new ResponseVM()
                        {
                            IsSuccess = false,
                            Message = "حدث خطأ اثناء التسجيل"
                        };
                    }

                }
                return new ResponseVM()
                {
                    IsSuccess = false,
                    Message = "ادخل البيانات بشكل صحيح"
                };
            }
            catch
            {
                return new ResponseVM()
                {
                    IsSuccess = false,
                    Message = "حدث خطأ اثناء التسجيل"
                };
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginVM userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.LogIn(userLogin);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Error in Login");
                return BadRequest(ModelState);
            }
            var token = _userService.CreateToken(userLogin);
            return Ok(token);

        }

        [HttpGet("getUser")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult getUser()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var Id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;
                var user = _dBContext.Users.Find(Id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<ApplicationUser, UserProfileVM>(user));

            }
            return BadRequest();
        }
    }
}
