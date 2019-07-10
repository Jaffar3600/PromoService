using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using PromoServiceMongoDB.Model;

namespace PromoServiceMongoDB.DataAccess.Utility
{
    public class CosmosDataAdapter : ICosmosDataAdapter
    {


        private readonly DocumentClient _client;
        private readonly string _accountUrl;
        private readonly string _primarykey;

        public CosmosDataAdapter(ICosmosConnection connection, IConfiguration config)
        {

            _accountUrl = config.GetValue<string>("Cosmos:AccountURL");
            _primarykey = config.GetValue<string>("Cosmos:AuthKey");
            _client = new DocumentClient(new Uri(_accountUrl), _primarykey);
        }

        public async Task Add(string dbName, string name)
        {
            var result = await _client.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(dbName), new DocumentCollection { Id = name });    
        }

        public async Task<bool> CreateDocument(string dbName, string name, ProductPromo productpromo)
        {
            await _client.CreateDocumentCollectionIfNotExistsAsync
                 (UriFactory.CreateDatabaseUri(dbName), new DocumentCollection { Id = name });


            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPromo>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProductPromo> Get(string id)
        {
            throw new NotImplementedException();
        }

        




    }
}
