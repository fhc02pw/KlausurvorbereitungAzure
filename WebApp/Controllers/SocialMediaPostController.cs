using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.Storage.Queue.Protocol;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("socialmedia")]
    [ApiController]
    public class SocialMediaPostController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SocialMediaPostController(IConfiguration config)
        {
            //Get configuration (Appsettings) through dependency injection
            this._config = config;
        }

        [HttpPost]
        public void postMethod([FromBody]SocialMediaPost post)
        {
            //Get Storage account
            var connectionString = _config.GetValue<string>("ConnectionStrings:StorageAccount"); 
            var csa = CloudStorageAccount.Parse(connectionString);
            var queueclient = csa.CreateCloudQueueClient();

            //Create queue
            var queueRef = queueclient.GetQueueReference("socialmediaposts");
            queueRef.CreateIfNotExists();

            //Add message to queue
            var postAsJson = JsonConvert.SerializeObject(post);
            var qm = new CloudQueueMessage(postAsJson);
            queueRef.AddMessage(qm); 

        }

        [HttpGet("{id}")]
        public Task<SocialMediaPostCosmosDb> getSinglePost(string id)
        {
            //https://localhost:44318/socialmedia/c661aa4d-24f0-488e-b14e-3474762e4ccb
            return DatabaseReader.GetPost(id);
        }

        [HttpGet]
        public Task<IList<SocialMediaPostCosmosDb>> getPosts(string topic)
        {
            //https://localhost:44318/socialmedia?topic=Irgendwas
            return DatabaseReader.GetPosts(topic); 
        }
    }
}