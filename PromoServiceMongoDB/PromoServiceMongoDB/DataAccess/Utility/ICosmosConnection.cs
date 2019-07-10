using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;

namespace PromoServiceMongoDB.DataAccess.Utility
{
    public interface ICosmosConnection
    {
        Task<DocumentClient> InitializeAsync(string collectionId);

    }
}
