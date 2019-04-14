using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpiderWeb.API.Data;
using SpiderWeb.API.Dtos;
using SpiderWeb.API.Models;

namespace SpiderWeb.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config,  IMapper mapper){
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await _repo.UserExits( userForRegisterDto.Username))
                return BadRequest("Username already exists");
        

        var UserToCreate = _mapper.Map<User>(userForRegisterDto);

       

        var createUser = await _repo.Register(UserToCreate, userForRegisterDto.Password);
         var userToReturn = _mapper.Map<UserDetailedDto>(createUser);
        return  CreatedAtRoute("GetUser", new {controller = "Users", id = createUser.Id},userToReturn );
    }

    
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto UserForLoginDto)
        {
            var useFromRepo = await _repo.Login(UserForLoginDto.Username.ToLower(), UserForLoginDto.Password);
            if(useFromRepo == null)
                return Unauthorized();
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, useFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, useFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var user = _mapper.Map<UserForListDto>(useFromRepo);
            return Ok(new {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}