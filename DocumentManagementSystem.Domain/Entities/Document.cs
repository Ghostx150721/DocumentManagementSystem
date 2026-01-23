using System;
using System.Collections.Generic;
using DocumentManagementSystem.Domain.Exceptions;

namespace DocumentManagementSystem.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Owner { get; private set; }
        public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();
        public bool IsDeleted { get; private set; }

        private readonly List<string> _tags = new();
        private readonly List<DocumentVersion> _versions = new();

        public IReadOnlyCollection<DocumentVersion> Versions => _versions.AsReadOnly();

        private Document() { } // for ORM or serialization

        public Document(string title, string owner)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ValidationException("Document title cannot be empty.");

            if (string.IsNullOrWhiteSpace(owner))
                throw new ValidationException("Document owner cannot be empty.");

            Id = Guid.NewGuid();
            Title = title;
            Owner = owner;
        }

        public DocumentVersion AddVersion(string filePath, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ValidationException("File path cannot be empty.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new ValidationException("CreatedBy cannot be empty.");

            var version = new DocumentVersion
            (
                Id,
                filePath,
                createdBy,
                _versions.Count + 1
            );

            _versions.Add(version);
            return version;
        }

        public void AddTag(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                throw new ValidationException("Tag cannot be empty.");

            if (!_tags.Contains(tag))
                _tags.Add(tag);
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
