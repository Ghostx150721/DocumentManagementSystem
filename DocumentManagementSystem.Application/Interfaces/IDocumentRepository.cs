
using System.Reflection.Metadata;

namespace DocumentManagementSystem.AppCore.Interfaces
{
    public interface IDocumentRepository
    {
        void Add(Domain.Entities.Document document);
        Domain.Entities.Document GetById(Guid id);
    }
}
