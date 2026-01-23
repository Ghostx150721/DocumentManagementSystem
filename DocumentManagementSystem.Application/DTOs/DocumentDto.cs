using System;

namespace DocumentManagementSystem.AppCore.DTOs
{
    public record DocumentDto(
        Guid Id,
        string Title,
        string Owner,
        bool IsDeleted
    );
}
