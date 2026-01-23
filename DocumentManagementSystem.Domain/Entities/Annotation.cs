using DocumentManagementSystem.Domain.Enums;
using DocumentManagementSystem.Domain.ValueObjects;
using System;
using System.Drawing;
using DocumentManagementSystem.Domain.Exceptions;
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

        public Annotation(
            AnnotationType type,
            int pageNumber,
            Rectangle bounds,
            string author)
        {
            if (pageNumber <= 0)
                throw new ValidationException("Page number must be greater than zero.");

            if (bounds.Width <= 0 || bounds.Height <= 0)
                throw new ValidationException("Annotation bounds must be valid.");

            if (string.IsNullOrWhiteSpace(author))
                throw new ValidationException("Author is required.");

            Id = Guid.NewGuid();
            Type = type;
            PageNumber = pageNumber;
            Bounds = bounds;
            Author = author;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
