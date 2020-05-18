using Microsoft.Azure.Cosmos;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class DatabaseReader
    {
        private static string connectionString = "AccountEndpoint=https://cosmosdbweihs.documents.azure.com:443/;AccountKey=PzKk7a2OzmuxMWMafTfeIQzxi3Ova66poRLlMXDeCaVCZ95NKwDBSHCSxaW7WMpDlDZZzAwrNPDTPoL3EuV7Qg==;";
        public static async Task<SocialMediaPostCosmosDb> GetPost(string id)
        {
            var cc = new CosmosClient(connectionString);
            Database db = await cc.CreateDatabaseIfNotExistsAsync("socialmedia");
            Container c = await db.CreateContainerIfNotExistsAsync("posts", "/partition");

            return await c.ReadItemAsync<SocialMediaPostCosmosDb>(id, new PartitionKey("Testpartition"));
        }

        public static async Task<IList<SocialMediaPostCosmosDb>> GetPosts(string topic)
        {
            var cc = new CosmosClient(connectionString);
            Database db = await cc.CreateDatabaseIfNotExistsAsync("socialmedia");
            Container c = await db.CreateContainerIfNotExistsAsync("posts", "/partition");

            var query = "SELECT * FROM c";
            if (topic != null)
                query += " WHERE c.topicDb = '" + topic + "'";

            var iterator = c.GetItemQueryIterator<SocialMediaPostCosmosDb>(query);
            var result = new List<SocialMediaPostCosmosDb>(); 

            while(iterator.HasMoreResults)
            {
                var nextElements = await iterator.ReadNextAsync(); 
                foreach(var elem in nextElements)
                {
                    result.Add(elem); 
                }
            }

            return result; 
        }
    }
}
