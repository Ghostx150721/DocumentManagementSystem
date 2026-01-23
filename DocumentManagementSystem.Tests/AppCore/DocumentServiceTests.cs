using Xunit;
using DocumentManagementSystem.AppCore.Commands;
using DocumentManagementSystem.AppCore.Services;
using DocumentManagementSystem.Tests.Fakes;
using DocumentManagementSystem.Domain.Exceptions;

namespace DocumentManagementSystem.Tests.AppCore
{
    public class DocumentServiceTests
    {
        [Fact]
        public void Create_creates_document_and_returns_dto()
        {
            // Arrange
            var repository = new FakeDocumentRepository();
            var service = new DocumentService(repository);

            var command = new CreateDocumentCommand(
                Title: "Project Plan",
                Owner: "Hirusha"
            );

            // Act
            var result = service.Create(command);

            // Assert
            Assert.NotEqual(default, result.Id);
            Assert.Equal("Project Plan", result.Title);
            Assert.Equal("Hirusha", result.Owner);
            Assert.False(result.IsDeleted);

            var stored = repository.GetById(result.Id);
            Assert.NotNull(stored);
        }

        [Fact]
        public void Create_with_empty_title_throws_validation_exception()
        {
            var repository = new FakeDocumentRepository();
            var service = new DocumentService(repository);

            var command = new CreateDocumentCommand(
                Title: "",
                Owner: "Hirusha"
            );

            Assert.Throws<ValidationException>(() =>
                service.Create(command));
        }
    }
}
