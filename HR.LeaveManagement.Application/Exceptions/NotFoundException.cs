using System;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} with id {key} not found")
        {

        }
    }
}
