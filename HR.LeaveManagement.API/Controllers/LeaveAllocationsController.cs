using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.DeleteLeaveAllocation;
using HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.UseCases.LeaveAllocations.Queries.GetLeaveAllocationDetail;
using HR.LeaveManagement.Application.UseCases.LeaveAllocations.Queries.GetLeaveAllocationList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveAllocationsController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
    {
        var LeaveAllocations = await _mediator.Send(new GetLeaveAllocationListQuery());
        return Ok(LeaveAllocations);
    }

    // GET api/<LeaveAllocationsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var LeaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery { Id = id });
        return Ok(LeaveAllocation);
    }

    // POST api/<LeaveAllocationsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto LeaveAllocation)
    {
        var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = LeaveAllocation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<LeaveAllocationsController>
    [HttpPut()]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
    {
        var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = leaveAllocation };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<LeaveAllocationsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveAllocationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
