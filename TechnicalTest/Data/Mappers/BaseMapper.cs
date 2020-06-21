using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Data
{
    public abstract class BaseMapper
    {
        public static string EndpointUri { private get; set; }
        public static string PrimaryKey { private get; set; }
        public static string DatabaseId { private get; set; }

        protected Container Container { get; private set; }

        private CosmosClient _cosmosClient;
        private Database _database;
        private readonly string _containerId;
        private readonly string _partitionKey;

        protected BaseMapper(string containerId, string partitionKey)
        {
            _containerId = containerId;
            _partitionKey = partitionKey;
            Task asyncTask = InitializeAsync();
            asyncTask.Wait();
        }

        private async Task InitializeAsync()
        {
            _cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
            _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseId);
            Container = await _database.CreateContainerIfNotExistsAsync(_containerId, _partitionKey);
        }
    }
}
