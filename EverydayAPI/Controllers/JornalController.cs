using EverydayAPI.Data;
using EverydayAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EverydayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JornalController : Controller{
        private readonly EverydayAPIDbContext dbContext;
        public JornalController(EverydayAPIDbContext dbContext){
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJornais(){
            return Ok(await dbContext.jornais.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetJornal([FromRoute] Guid id){
            var jornal = await dbContext.jornais.FindAsync(id);
            if (jornal == null)
            {
                return NotFound();
            }
            return Ok(jornal);
        }

        [HttpPost]
        public async Task<IActionResult> AddJornais(AddJornalRequest addJornalRequest){
            var jornal = new Jornal()
            {
                jornalId = Guid.NewGuid(),
                autorId = addJornalRequest.autorId,
                link = addJornalRequest.link,
                descricao = addJornalRequest.descricao,
                sinopse = addJornalRequest.sinopse,
                titulo = addJornalRequest.titulo,
                assunto = addJornalRequest.assunto
            };

            await dbContext.jornais.AddAsync(jornal);
            await dbContext.SaveChangesAsync();

            return Ok(jornal);
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateJornais([FromRoute] Guid id, UpdateJornalRequest updateJornalRequest){
            var jornal = await dbContext.jornais.FindAsync(id);

            if (jornal != null){
                jornal.link = updateJornalRequest.link;
                jornal.descricao = updateJornalRequest.descricao;
                jornal.sinopse = updateJornalRequest.sinopse;
                jornal.titulo = updateJornalRequest.titulo;
                jornal.assunto = updateJornalRequest.assunto;

                await dbContext.SaveChangesAsync();

                return Ok(jornal);
            }

            return NotFound();
        }
    }
}