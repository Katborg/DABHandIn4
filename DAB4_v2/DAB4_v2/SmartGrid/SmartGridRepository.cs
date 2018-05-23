using System;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace SmartGrid
{
	public class SmartGridRepository : DbRepository<DAB4.Models.SmartGrid>, ISmartGridRepository
    {
        public SmartGridRepository(string dbId, string collectionId) : base(dbId, collectionId)
        {
        }

        public DAB4.Models.SmartGrid ReplaceSmartGridDocument(int id, DAB4.Models.SmartGrid updatedGrid)
        {
            if (id == Convert.ToInt32(updatedGrid.Id))
            {
                DAB4.Models.SmartGrid p = Get(id);
                if (p != null)
                {
                    Client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id.ToString()),
                        updatedGrid).Wait();
                    return updatedGrid;
                }
            }
            return null;
        }
    }
}
