using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.UseCases.LeaveTypes;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Queries.GetLeaveTypeDetail;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Queries.GetLeaveTypeList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [Authorize]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeListQuery());
        return Ok(leaveTypes);
    }

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        try
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailQuery { Id = id });
            return Ok(leaveType);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            throw;
        }
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
        try
        {
            var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        catch
        {
            throw;
        }
    }

    // PUT api/<LeaveTypesController>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] LeaveTypeDto leaveType)
    {
        var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType };
        try
        {
            var response = await _mediator.Send(command);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            throw;
        }
    }

    // DELETE api/<LeaveTypesController>/5
    /// <response code="204" nullable="true">No data.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            throw;
        }
    }
}
