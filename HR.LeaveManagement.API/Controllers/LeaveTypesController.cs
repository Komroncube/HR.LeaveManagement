using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Queries.GetLeaveTypeDetail;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Queries.GetLeaveTypeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveTypesController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeListQuery());
        return Ok(leaveTypes);
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailQuery { Id = id });
        return Ok(leaveType);
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<LeaveTypesController>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
    {
        var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveTypeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
