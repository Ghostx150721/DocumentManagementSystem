using System;
using DocumentManagementSystem.AppCore.Commands;
using DocumentManagementSystem.AppCore.Interfaces;
using DocumentManagementSystem.AppCore.DTOs;
using DocumentManagementSystem.Domain.Entities;

namespace DocumentManagementSystem.AppCore.Services
{
    public class DocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public DocumentDto Create(CreateDocumentCommand command)
        {
            var document = new Document(
                command.Title,
                command.Owner
            );

            _repository.Add(document);

            return new DocumentDto(
                document.Id,
                document.Title,
                document.Owner,
                document.IsDeleted
            );
        }
    }
}
