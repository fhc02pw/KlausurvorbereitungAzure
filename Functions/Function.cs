using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.Models;

namespace Functions
{
    public static class Function
    {
        [FunctionName("SocialMediaPostFunction")]
        public static void Run(
            [QueueTrigger("socialmediaposts", Connection = "StorageAccountConnectionString")]string postAsJson, 
            [CosmosDB(databaseName: "socialmedia", collectionName: "posts", ConnectionStringSetting = "CosmosDbConnectionString", CreateIfNotExists = true, PartitionKey = "/partition")]out dynamic document,
            ILogger log)
        {
            //Connection and ConnectionStringSettings is the name of the value in the local.settings.json

            var post = JsonConvert.DeserializeObject<SocialMediaPost>(postAsJson);
            document = new
            {
                idDb = Guid.NewGuid(), 
                topicDb = post.topic, 
                postDb = post.post, 
                commentsDb = post.comments, 
                partition = "Testpartition"
            };
        }
    }
}
