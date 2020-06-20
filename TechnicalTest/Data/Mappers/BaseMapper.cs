using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Data
{
    public abstract class BaseMapper
    {
        protected Container Container { get; private set; }

        private CosmosClient _cosmosClient;
        private Database _database;
        private readonly string _endpointUri;
        private readonly string _primaryKey;
        private readonly string _databaseId;
        private readonly string _containerId;
        private readonly string _partitionKey;

        protected BaseMapper(string containerId, string partitionKey) : this("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "technicalTest", containerId, partitionKey) { }
        protected BaseMapper(string endpointUri, string primaryKey, string databaseId, string containerId, string partitionKey)
        {
            _endpointUri = endpointUri;
            _primaryKey = primaryKey;
            _databaseId = databaseId;
            _containerId = containerId;
            _partitionKey = partitionKey;
            Task asyncTask = InitializeAsync();
            asyncTask.Wait();
        }

        private async Task InitializeAsync()
        {
            _cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
            _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseId);
            Container = await _database.CreateContainerIfNotExistsAsync(_containerId, _partitionKey);
        }
    }
}
