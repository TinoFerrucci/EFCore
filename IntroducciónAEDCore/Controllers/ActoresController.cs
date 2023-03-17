using AutoMapper;
using IntroducciónAEDCore.DTOs;
using IntroducciónAEDCore.Entidades;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacion)
        {
            var actor = mapper.Map<Actor>(actorCreacion);
            context.Add(actor);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
