using Application.Features.Departments.Commands.CreateDepartmentCommand;
using Application.Features.Departments.Commands.DeleteDepartmentCommand;
using Application.Features.Departments.Commands.GetDepartmentById;
using Application.Features.Departments.Commands.UpdateDepartmentCommand;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDepartmentByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDepartmentCommand command)
        {
            if (id != command.Id) return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDepartmentCommand() { Id = id }));
        }
    }
}