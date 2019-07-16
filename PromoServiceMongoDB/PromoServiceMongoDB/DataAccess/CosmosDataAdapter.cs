using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using PromoServiceMongoDB.Model;
//using PromoServiceMongoDB.Model;

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

      



        public async Task<bool> CreateDocument(string dbName, string name, ProductPromo productpromo)
        {
            try
            {
               // productpromo.Id = "d9e51c1e-1474-41d1-8f32-96deedd8f36a";
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromo);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public async Task<bool> CreateDocumentAsync(string dbName, string name, ProductPromoAction productpromoaction)
        {
            try
            {
                // productpromo.Id = "d9e51c1e-1474-41d1-8f32-96deedd8f36a";
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromoaction);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public async Task<ProductPromo> DeleteUserAsync(string dbName, string name, string id)
        {
            try
            {
                var collectionUri = UriFactory.CreateDocumentUri(dbName, name, id);

                var result = await _client.DeleteDocumentAsync(collectionUri);

                return (dynamic)result.Resource;
            }
            catch (DocumentClientException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }


/*
            MyItem item = (dynamic)_client.ReadDocumentAsync(
                UriFactory.CreateDocumentUri(dbName, name, id),
                new RequestOptions()
                {
                    PartitionKey = new PartitionKey(Undefined.Value)
                }).Result.Resource;

            var result = await _client.DeleteDocumentAsync(
                 UriFactory.CreateDocumentUri(dbName, name, id),
                 new RequestOptions()
                 {
                     PartitionKey = new PartitionKey(Undefined.Value)
                 });
            return (dynamic)result.Resource;*/


        }


        public async Task<bool> CreateDocument(string dbName, string name, ProductPromoAction productpromoaction)
        {

            try
            {
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromoaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> updateDocumentAsync(string dbName, string name, ProductPromo productpromo)
        {
            try
            {
                
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        async Task<dynamic> ICosmosDataAdapter.GetDataAsync(string dbName, string name)
        {
            var result = await _client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri(dbName, name),
                    new FeedOptions { MaxItemCount = 10 });

            return result;
        }

        public async Task<bool> updateDocumentAsync(string dbName, string name, ProductPromoAction productpromoaction, string id)
        {
            try
            {

                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromoaction);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
