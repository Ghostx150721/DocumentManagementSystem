

namespace DocumentManagementSystem.AppCore.Commands
{
    public record CreateDocumentCommand(
        string Title,
        string Owner
    );
}
