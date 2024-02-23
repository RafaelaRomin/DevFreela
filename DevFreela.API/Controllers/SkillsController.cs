using DevFreela.Application.Commands.CreateSkill;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id }, command);
        }
        
    }
}
