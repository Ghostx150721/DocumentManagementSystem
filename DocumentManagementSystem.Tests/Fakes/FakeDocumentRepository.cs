using System;
using System.Collections.Generic;
using DocumentManagementSystem.AppCore.Interfaces;
using DocumentManagementSystem.Domain.Entities;

namespace DocumentManagementSystem.Tests.Fakes
{
    public class FakeDocumentRepository : IDocumentRepository
    {
        private readonly Dictionary<Guid, Document> _store = new();

        public void Add(Document document)
        {
            _store[document.Id] = document;
        }

        public Document? GetById(Guid id)
        {
            return _store.TryGetValue(id, out var doc) ? doc : null;
        }
    }
}
