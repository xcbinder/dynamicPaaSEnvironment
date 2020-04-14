// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Azure.Documents.Client;
using static System.Environment;

namespace ExampleFunctions
{
    public static class SaveToCosmos
    {
        [FunctionName("SaveToCosmos")]
        public static void Run(
            [EventGridTrigger]EventGridEvent eventGridEvent,
            [CosmosDB(
                databaseName: "%database_name%",
                collectionName: "%collection_name%",
                ConnectionStringSetting = "CosmosDBConnection")] out object document,
            ILogger log)
        {
           
            log.LogInformation(eventGridEvent.Data.ToString());
            document = new { Description = eventGridEvent.Data.ToString(), id = Guid.NewGuid() };
        }
    }
}
