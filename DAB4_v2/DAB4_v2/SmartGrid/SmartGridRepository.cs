using System;
using SmartGrid.SmartGridInfo;
using Microsoft.Azure.Documents.Client;

namespace SmartGrid
{
	public class SmartGridRepository : Repository<DAB4.Models.SmartGrid>
    {
		private static string dbID = "SmartGridInfo_oa";
	    private static string collectionID = "SmartGridInfoCol";
	    private const string EndpointUri = "https://f18i4dab.documents.azure.com:443/";
	    private const String PrimaryKey = "vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==";
	    private static readonly DocumentClient _client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

	    public SmartGridRepository() : base(_client, dbID, collectionID)
	    {

	    }

	}
}
