using System;
using System.Collections.Generic;

namespace DocumentManagementSystem.Domain.Entities
{
    public class DocumentVersion
    {
        public Guid Id { get; private set; }
        public Guid DocumentId { get; private set; }
        public int VersionNumber { get; private set; }
        public string FilePath { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Annotation> _annotations = new();
        public IReadOnlyCollection<Annotation> Annotations => _annotations.AsReadOnly();

        private DocumentVersion() { }

        internal DocumentVersion(Guid documentId, string filePath, string createdBy, int versionNumber)
        {
            Id = Guid.NewGuid();
            DocumentId = documentId;
            FilePath = filePath;
            CreatedBy = createdBy;
            VersionNumber = versionNumber;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddAnnotation(Annotation annotation)
        {
            _annotations.Add(annotation);
        }
    }
}
