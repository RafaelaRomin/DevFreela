using DevFreela.Application.Commands.CreateSkillFreelancer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users-skills")]
    [Authorize]
    public class UserSkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserSkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        [Authorize(Roles = "freelancer")]
        public async Task<IActionResult> UpdateUserSkills([FromBody] CreateSkillFreelancerCommand command)
        {
            var userSkills = await _mediator.Send(command);

            return Ok(userSkills);
        }

    }
}
