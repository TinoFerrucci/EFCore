using AutoMapper;
using IntroducciónAEDCore.DTOs;
using IntroducciónAEDCore.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IntroducciónAEDCore.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            var genero = mapper.Map<Genero>(generoCreacion);
            context.Add(genero);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generoCreacion)
        {
            var generos = mapper.Map<Genero[]>(generoCreacion);
            context.AddRange(generos);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<Genero> Put(int generoId, GeneroCreacionDTO generoCreacion)
        {
            var genero = mapper.Map<Genero> (generoCreacion);
            genero.Id = generoId;

            var modifyGenero = context.Generos.Where(g => g.Id == genero.Id).FirstOrDefault();
            modifyGenero.Nombre = genero.Nombre;

            await context.SaveChangesAsync();

            return genero;
        }
    }
}
