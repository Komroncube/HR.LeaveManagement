using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.DeleteLeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveReqeustList;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveRequestDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveRequestsController>
    [HttpGet]
    public async Task<ActionResult<IList<LeaveRequestListDto>>> Get()
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestListQuery());
        return Ok(leaveRequests);
    }

    // GET api/<LeaveRequestsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailQuery { Id = id });
        return Ok(leaveRequest);
    }

    // POST api/<LeaveRequestsController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<LeaveRequestsController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, UpdateLeaveRequestDto = leaveRequest };
        var response = await _mediator.Send(command);
        return NoContent();
    }
    // PUT api/<LeaveRequestsController>/changeapproval/5
    [HttpPut("changeapproval/{id}")]
    public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveReqeustApprovalDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveReqeustApprovalDto = leaveRequest };
        var response = await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<LeaveRequestsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
        return NoContent();
    }
}
