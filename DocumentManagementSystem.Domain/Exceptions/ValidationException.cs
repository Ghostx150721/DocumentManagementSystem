using System;

namespace DocumentManagementSystem.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
