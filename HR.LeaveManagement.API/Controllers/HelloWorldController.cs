using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class HelloWorldController : ControllerBase
{
    /// <summary>
    /// Returns a simple hello world message
    /// </summary>
    /// <returns>Hello world message</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Get()
    {
        return Ok("Hello World from HR Leave Management API!");
    }

    /// <summary>
    /// Returns a personalized hello world message
    /// </summary>
    /// <param name="name">Name to personalize the greeting</param>
    /// <returns>Personalized hello world message</returns>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Get(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Ok("Hello World from HR Leave Management API!");
        
        return Ok($"Hello {name} from HR Leave Management API!");
    }
}