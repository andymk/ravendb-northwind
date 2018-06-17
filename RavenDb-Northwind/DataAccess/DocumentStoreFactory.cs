using System;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;

namespace RavenDb_Northwind.DataAccess
{
    public class DocumentStoreFactory : IDocumentStoreFactory
    {
        public IDocumentStore Store { get; private set; }

        public DocumentStoreFactory(IOptions<RavenSettings> options)
        {
            var settings = options.Value;

            Store = new DocumentStore
            {
                Urls = new string[] { settings.Url  ?? "http://localhost:8080" },
                Database = settings.DefaultDatabase ?? "northwind"
            }.Initialize();
        }
    }
}
