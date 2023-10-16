using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace AzureFunctionAppSample
{
    public static class UploadBlobFunction
    {
        [FunctionName("UploadBlobFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "upload")] HttpRequest req,
            ILogger log)
        {
            // Retrieve the connection string from configuration
            string storageConnectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            // Parse the connection string and create a CloudStorageAccount object
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            // Create the CloudBlobClient that represents the Blob Storage service
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

            // Create the container if it doesn't exist
            await container.CreateIfNotExistsAsync();

            // Retrieve the uploaded image from the request
            var file = req.Form.Files["file"];

            // Generate a unique blob name (e.g., using a GUID)
            string blobName = $"{System.Guid.NewGuid()}.jpg"; // You may want to change the file extension based on the uploaded image's actual format

            // Retrieve reference to a blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Upload the image to the blob
            using (var stream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(stream);
            }

            return new OkObjectResult($"Blob {blobName} uploaded successfully.");
        }
    }
}
