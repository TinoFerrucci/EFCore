using AutoMapper;
using IntroducciónAEDCore.DTOs;
using IntroducciónAEDCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroducciónAEDCore.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<Actor> Post(ActorCreacionDTO actorCreacion)
        {
            var actor = mapper.Map<Actor>(actorCreacion);
            context.Add(actor);
            await context.SaveChangesAsync();

            return actor;
        }

        [HttpGet]
        public async Task<List<Actor>> Get()
        {
            var actor = await context.Actores.ToListAsync();

            return actor;
        }

        [HttpPut]
        public async Task<Actor> Put(int actorId, ActorCreacionDTO actorCreacion)
        {
            var actor = mapper.Map<Actor>(actorCreacion);
            actor.Id = actorId;

            var modifyActor = context.Actores.Where(x => x.Id == actorId);
            modifyActor.FirstOrDefault().Nombre = actor.Nombre;
            modifyActor.FirstOrDefault().Fortuna = actor.Fortuna;
            modifyActor.FirstOrDefault().FechaNacimiento = actor.FechaNacimiento;

            await context.SaveChangesAsync();

            return actor;
        }

        [HttpDelete]
        public async Task<string> Delete(int actorId)
        {
            var deleteActor = context.Actores.Where(x => x.Id == actorId).FirstOrDefault();
            context.Actores.Remove(deleteActor);

            await context.SaveChangesAsync();

            return "El actor fue borrado con exito";
        }
    }
}
