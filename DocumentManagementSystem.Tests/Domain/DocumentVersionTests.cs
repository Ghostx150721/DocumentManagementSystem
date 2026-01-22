using System;
using Xunit;
using DocumentManagementSystem.Domain.Entities;
using DocumentManagementSystem.Domain.Enums;
using DocumentManagementSystem.Domain.ValueObjects;
using DocumentManagementSystem.Domain.Exceptions;

namespace DocumentManagementSystem.Tests.Domain
{
    public class DocumentVersionTests
    {
        [Fact]
        public void CanAddAnnotation()
        {
            var doc = new Document("Contract", "Hirusha");
            var version = doc.AddVersion("file1.pdf", "Hirusha");

            var annotation = new Annotation(
                AnnotationType.Stamp,
                1,
                new Rectangle(10, 20, 100, 50),
                "Hirusha"
            );

            version.AddAnnotation(annotation);

            Assert.Single(version.Annotations);
            Assert.Equal(AnnotationType.Stamp, version.Annotations.First().Type);
            Assert.Equal("Hirusha", version.Annotations.First().Author);
        }

        [Fact]
        public void Adding_annotation_with_invalid_page_throws_exception()
        {
            var doc = new Document("Contract", "Hirusha");
            var version = doc.AddVersion("file.pdf", "Hirusha");

            Assert.Throws<ValidationException>(() =>
                new Annotation(
                    AnnotationType.Stamp,
                    pageNumber: 0,
                    bounds: new Rectangle(1, 1, 10, 10),
                    author: "Hirusha"
                ));
        }

    }
}
