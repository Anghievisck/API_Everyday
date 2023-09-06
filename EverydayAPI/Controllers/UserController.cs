using EverydayAPI.Data;
using EverydayAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EverydayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller{
        private readonly EverydayAPIDbContext dbContext;
        public UserController(EverydayAPIDbContext dbContext){
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            return Ok(await dbContext.users.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id){
            var user = await dbContext.users.FindAsync(id);
            if (user == null){
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(AddUserRequest addUserRequest){
            var user = new User(){
                id = Guid.NewGuid(),
                username = addUserRequest.username,
                password = addUserRequest.password,
                userEmail = addUserRequest.userEmail,
                jornalFavorito = addUserRequest.jornalFavorito
            };

            await dbContext.users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUsers([FromRoute] Guid id, UpdateUserRequest updateUserRequest){
            var user = await dbContext.users.FindAsync(id);

            if (user != null){
                user.userEmail = updateUserRequest.userEmail;
                user.password = updateUserRequest.password;
                user.jornalFavorito = updateUserRequest.jornalFavorito;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }

            return NotFound();
        }
    }
}