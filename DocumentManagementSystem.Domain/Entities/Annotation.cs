using DocumentManagementSystem.Domain.Enums;
using DocumentManagementSystem.Domain.ValueObjects;
using System;
using System.Drawing;
using Rectangle = DocumentManagementSystem.Domain.ValueObjects.Rectangle;

namespace DocumentManagementSystem.Domain.Entities
{
    public class Annotation
    {
        public Guid Id { get; private set; }
        public AnnotationType Type { get; private set; }
        public int PageNumber { get; private set; }
        public Rectangle Bounds { get; private set; }
        public string Author { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Annotation() { }

        public Annotation(AnnotationType type, int pageNumber, Rectangle bounds, string author)
        {
            Id = Guid.NewGuid();
            Type = type;
            PageNumber = pageNumber;
            Bounds = bounds;
            Author = author;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
