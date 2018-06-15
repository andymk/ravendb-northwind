using Raven.Client.Documents;

namespace RavenDb_Northwind.DataAccess
{
    public interface IDocumentStoreFactory
    {
        IDocumentStore Store { get; }
    }
}
