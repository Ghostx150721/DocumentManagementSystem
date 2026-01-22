using System;
using System.Collections.Generic;

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
            Id = Guid.NewGuid();
            Title = title;
            Owner = owner;
        }

        public DocumentVersion AddVersion(string filePath, string createdBy)
        {
            var version = new DocumentVersion(Id, filePath, createdBy, _versions.Count + 1);
            _versions.Add(version);
            return version;
        }

        public void AddTag(string tag)
        {
            if (!_tags.Contains(tag))
                _tags.Add(tag);
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
