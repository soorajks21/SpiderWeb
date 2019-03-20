using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public AuthController(IAuthRepository repo){
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await _repo.UserExits( userForRegisterDto.Username))
                return BadRequest("Username already exists");
        

        var UserToCreate = new User
        {
                Username =  userForRegisterDto.Username
        };

        var createUser = await _repo.Register(UserToCreate, userForRegisterDto.Password);
        return StatusCode(201);
    }

    

    }
}