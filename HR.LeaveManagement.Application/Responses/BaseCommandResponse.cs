using System.Collections.Generic;

namespace HR.LeaveManagement.Application.Responses;
public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}
