using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GelAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]

    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {

            _mediator = mediator;
        }
        
        [HttpGet]
        //[Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(GetAllProjectsQuery getAllProjectsQuery)
        {
            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id) 
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        //[Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "client")]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command, int id)
        {
            await _mediator.Send(command);    

            return NoContent();
        }

        [HttpDelete("id")]
        //[Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        //[Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult>  PostComment([FromBody]CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        //[Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);    

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        //[Authorize(Roles = "client, freelancer")]
        public async Task <IActionResult> Finish(int id, [FromBody] FinishProjectCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("O pagamento não pode ser processado");
            }
            return Accepted();
        }

    }
}
