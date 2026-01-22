using System;
using Xunit;
using DocumentManagementSystem.Domain.Entities;
using DocumentManagementSystem.Domain.Exceptions;

namespace DocumentManagementSystem.Tests.Domain
{
    public class DocumentTests
    {
        [Fact]
        public void CanCreateDocument()
        {
            var doc = new Document("Contract", "Hirusha");

            Assert.NotNull(doc.Id);
            Assert.Equal("Contract", doc.Title);
            Assert.Equal("Hirusha", doc.Owner);
            Assert.Empty(doc.Versions);
            Assert.False(doc.IsDeleted);
        }

        [Fact]
        public void CanAddVersion_IncrementsVersionNumber()
        {
            var doc = new Document("Contract", "Hirusha");

            var v1 = doc.AddVersion("file1.pdf", "Hirusha");
            var v2 = doc.AddVersion("file2.pdf", "Hirusha");

            Assert.Equal(1, v1.VersionNumber);
            Assert.Equal(2, v2.VersionNumber);
            Assert.Equal(2, doc.Versions.Count);
        }

        [Fact]
        public void CanAddTag_TagAppearsOnce()
        {
            var doc = new Document("Report", "Hirusha");
            doc.AddTag("Important");
            doc.AddTag("Important"); // duplicate

            Assert.Single(doc.Tags);
            Assert.Contains("Important", doc.Tags);
        }

        [Fact]
        public void CanSoftDeleteDocument()
        {
            var doc = new Document("Invoice", "Hirusha");
            doc.SoftDelete();

            Assert.True(doc.IsDeleted);
        }

        [Fact]
        public void Creating_document_without_title_throws_exception()
        {
            Assert.Throws<ValidationException>(() =>
                new Document("", "Hirusha"));
        }
    }
}
