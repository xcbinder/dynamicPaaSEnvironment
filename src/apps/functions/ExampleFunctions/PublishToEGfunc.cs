using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.EventGrid;
using System.Collections;
using System.Collections.Generic;
using static System.Environment;

namespace ExampleFunctions
{
    public static class PublishToEGfunc
    {
        [FunctionName("PublishToEGfunc")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string domainEndpoint = GetEnvironmentVariable("EVENTGRID_DOMAIN_ENDPOINT");
            string domainKey = GetEnvironmentVariable("EVENTGRID_DOMAIN_KEY");
            string domainHostname = new Uri(domainEndpoint).Host;
            TopicCredentials domainKeyCredentials = new TopicCredentials(domainKey);
            EventGridClient client = new EventGridClient(domainKeyCredentials);

            client.PublishEventsAsync(domainHostname, GetEvents()).GetAwaiter().GetResult();
            Console.Write("Published events to Event Grid domain.");
            Console.ReadLine();

            return "Published events to Event Grid domain.";
        }

        private static IList<EventGridEvent> GetEvents()
        {
            Random random = new Random();
            // Return a list of events
            var events = new List<EventGridEvent>
            {
                new EventGridEvent()
                {
                    Id = Guid.NewGuid().ToString(),
                    Data = "Test" + random.Next(),
                    EventTime = DateTime.Now,
                    EventType = "EventGrid.Sample.EventSent",
                    Subject = "Test",
                    DataVersion = "1.0"
                }
            };
            return events;
        }
    }
}
