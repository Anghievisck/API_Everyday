using EverydayAPI.Data;
using EverydayAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EverydayAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : Controller {

        private readonly EverydayAPIDbContext dbContext;
        public AutorController(EverydayAPIDbContext dbContext){
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAutores(){
            return Ok(await dbContext.autors.ToListAsync());
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAutor([FromRoute] Guid id){
            var autor = await dbContext.autors.FindAsync(id);
            if(autor == null){
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> AddAutores(AddAutorRequest addAutorRequest){
            var autor = new Autor(){
                autorId = Guid.NewGuid(),
                name = addAutorRequest.name,
                link = addAutorRequest.link,
                descricao = addAutorRequest.descricao
            };

            await dbContext.autors.AddAsync(autor);
            await dbContext.SaveChangesAsync();

            return Ok(autor);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAutores([FromRoute] Guid id, UpdateAutorRequest updateAutorRequest) {
            var autor = await dbContext.autors.FindAsync(id);

            if (autor != null){
                autor.name = updateAutorRequest.name;
                autor.link = updateAutorRequest.link;
                autor.descricao = updateAutorRequest.descricao;

                await dbContext.SaveChangesAsync();

                return Ok(autor);
            }

            return NotFound();
        }
    }
}