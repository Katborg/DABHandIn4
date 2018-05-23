using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models.Persistence;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace SmartGrid
{
    public class DbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private const string EndpointUrl = "https://f18i4dab.documents.azure.com:443/";
        private const string PrimaryKey = "vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==";

        protected readonly DocumentClient Client;
        protected readonly string CollectionId;
        protected readonly string DatabaseId;

        public DbRepository(string dbId, string collectionId)
        {
            CollectionId = collectionId;
            DatabaseId = dbId;

            Client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

            Client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseId }).Wait();
            Client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId), new DocumentCollection { Id = CollectionId }).Wait();
        }
        public TEntity Get(int id)
        {
            try
            {
                Document document =
                    Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id.ToString())).Result;
                return (TEntity)(dynamic)document;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public IEnumerable<TEntity> GetAll()
        {
            IDocumentQuery<TEntity> query = Client
                .CreateDocumentQuery<TEntity>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                .AsDocumentQuery();

            List<TEntity> results = new List<TEntity>();
            while (query.HasMoreResults)
            {
                results.AddRange(query.ExecuteNextAsync<TEntity>().Result);
            }

            return results;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IDocumentQuery<TEntity> query = Client
                .CreateDocumentQuery<TEntity>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                .Where(predicate).AsDocumentQuery();
            List<TEntity> results = new List<TEntity>();
            while (query.HasMoreResults)
            {
                results.AddRange(query.ExecuteNextAsync<TEntity>().Result);
            }

            return results;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            try
            {
                this.Client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), entity).Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }


        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Add(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            Type type = entity.GetType();

            PropertyInfo property = type.GetProperty("Id");

            string id = property.GetValue(entity, null).ToString();

            Client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity person in entities)
            {
                Remove(person);
            }
        }
    }
}
