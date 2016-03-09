using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace AssociateRecords.Data
{
    public class AssociatesRepository
    {
        private const string EndpointUrl = "https://associatedb1.documents.azure.com:443/";
        private const string AuthorizationKey = "TbX8crsRuV9yU+MuoU3+lbplr0viH6ewoRWptziE8MylyT1u0N4+JFk8n66d7XRBFU58S0gNkzm18RyC2TpTkQ==";
        private readonly DocumentClient _documentClient;
        private Database _database;
        private DocumentCollection _documentCollection;

        public AssociatesRepository()
        {
            _documentClient = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);
            Initialise();
        }

        public async Task Initialise()
        {
            _database = await InitialiseDatabase();
            _documentCollection = await InitialiseDocumentCollection();
        }


        private async Task<Database> InitialiseDatabase()
        {
            // Check to verify a database with the id=FamilyRegistry does not exist
            var database = _documentClient.CreateDatabaseQuery()
                    .Where(db => db.Id == "AssociateRecords")
                    .AsEnumerable()
                    .FirstOrDefault();

            if (database == null)
            {
                database = await _documentClient.CreateDatabaseAsync(
                    new Database
                    {
                        Id = "AssociateRecords"
                    });
            }
            return database;
        }

        private async Task<DocumentCollection> InitialiseDocumentCollection()
        {
            // Check to verify a document collection with the id=FamilyCollection does not exist
            var documentCollection = _documentClient.CreateDocumentCollectionQuery("dbs/" + _database.Id)
                .Where(c => c.Id == "AssociateRecords").AsEnumerable().FirstOrDefault();


            // If the document collection does not exist, create a new collection
            if (documentCollection == null)
            {
                documentCollection = await _documentClient.CreateDocumentCollectionAsync("dbs/" + _database.Id,
                    new DocumentCollection
                    {
                        Id = "AssociateRecords"
                    });
            }
            return documentCollection;
        }



    }

}
