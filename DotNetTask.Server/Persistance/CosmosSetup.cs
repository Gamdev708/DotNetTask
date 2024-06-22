using Microsoft.Azure.Cosmos;

namespace DotNetTask.Server.Persistance
{
    public class CosmosSetup
    {

        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;

        public CosmosSetup(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
        }

        public async Task InitializeAsync()
        {
            var databaseId = "TestDb";
            var throughput = 400;

            // Create the database if it does not exist
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

            // Create the container if it does not exist
            await database.CreateContainerIfNotExistsAsync(new ContainerProperties
            {
                Id = "Form",
                PartitionKeyPath = "/Id"
            }, throughput);
            await database.CreateContainerIfNotExistsAsync(new ContainerProperties
            {
                Id = "FormProgram",
                PartitionKeyPath = "/Id"
            }, throughput);
            await database.CreateContainerIfNotExistsAsync(new ContainerProperties
            {
                Id = "FormQuestion",
                PartitionKeyPath = "/Id"
            }, throughput);
            await database.CreateContainerIfNotExistsAsync(new ContainerProperties
            {
                Id = "FormAnswers",
                PartitionKeyPath = "/Id"
            }, throughput);
        }

    }
}
