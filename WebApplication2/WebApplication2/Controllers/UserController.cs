using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Application.Interfaces.Repositories;
using WebApplication2.Application.Models.User;
using WebApplication2.Domain.Entities.User;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost(Name = "createuser")]
        public async Task<ActionResult<User>> CreateUser(CreateUserDto userdto)
        {
            if (userdto.RePassword == userdto.Password)
            {
                var user = new User()
                {
                    Password = userdto.Password,
                    UserName = userdto.UserName,
                    CreatedBy = "system",
                    CreatedAt = DateTime.Now,


                };
                var createuser = await _userRepository.Create(user);
                return Ok(createuser);
            }
            else { return BadRequest(); }

        }

        [HttpGet(Name = "GetAllUser")]
        public async Task<ActionResult<List<ShowUserDto>>> GetAllUser()
        {
            var createuser = await _userRepository.GetAll().Select(x => new ShowUserDto
            {
                Id = x.Id,
                Username = x.UserName,
                Firstname = x.FirstName,
                Lastname = x.LastName
            }
            ).ToListAsync();
            return Ok(createuser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var result = new ShowUserDto
            {
                Id = id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Username = user.UserName,
                CreatedBy = "system"
            };
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromQuery]int id , [FromBody]CreateUserDto userdto)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                user.UserName = userdto.UserName;
                user.UpdatedAt = DateTime.Now;
                var updateuser = await _userRepository.Update(user);
                return Ok(updateuser);
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var deleteuser = await _userRepository.Delete(user);
                return Ok();
            };
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<int>> GetId(int id)
        //{
        //    var user = await _userRepository.GetId(id);
        //    return Ok(user);
        //}


    }
}


