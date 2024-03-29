﻿using Application.Features.Departments.Commands.CreateDepartmentCommand;
using Application.Features.Departments.Commands.DeleteDepartmentCommand;
using Application.Features.Departments.Commands.GetallDepartments;
using Application.Features.Departments.Commands.GetDepartmentById;
using Application.Features.Departments.Commands.GetDepartmentsAmount;
using Application.Features.Departments.Commands.UpdateDepartmentCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetallDepartmentsParameters filter)
        {
            return Ok(await Mediator.Send(new GetallDepartmentsQuery()
            {
                // Name = filter.Name,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            }));
        }

        [HttpGet("amount")]
        public async Task<IActionResult> GetRecordsAmount()
        {
            return Ok(await Mediator.Send(new GetDepartmentsAmountQuery()));
        }

        [Authorize(Roles = "Admin")]
        // [Authorize]
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