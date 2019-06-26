using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.IoTHub;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebJobs.Extensions.IoTHub.Tests.Function
{
    public static class Functions
    {
        [FunctionName("DirectMethod")]
        public static async Task DirectMethod([HttpTrigger(AuthorizationLevel.Function, "post", Route = "DirectMethod/{deviceid}/{methodname}")] HttpRequest request,
            string deviceid,
            string methodname,
            [IoTDirectMethod(Connection = "iot")] IAsyncCollector<IoTDirectMethodItem> output, ILogger log)
        {
            log.LogInformation($"DirectMethod function executed at: {DateTime.Now}");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var item = new IoTDirectMethodItem
            {
                DeviceId = deviceid,
                MethodName = methodname,
                Payload = requestBody
            };
            await output.AddAsync(item);
        }

        [FunctionName("CloudToDeviceMessage")]
        public static async Task CloudToDeviceMessage([HttpTrigger(AuthorizationLevel.Function, "post", Route = "CloudToDeviceMessage/{deviceid}")] HttpRequest request,
            string deviceid,
            [IoTCloudToDevice(Connection = "iot")] IAsyncCollector<IoTCloudToDeviceItem> output,
            ILogger log)
        {
            log.LogInformation($"CloudToDeviceMessage function executed at: {DateTime.Now}");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();

            var item = new IoTCloudToDeviceItem
            {
                DeviceId = deviceid,
                Message = requestBody
            };
            await output.AddAsync(item);
        }



        [FunctionName("SetTwin")]
        public static async Task SetTwin([HttpTrigger(AuthorizationLevel.Function, "post", Route = "SetTwin/{deviceid}")] HttpRequest request,
            [IoTSetDeviceTwin(Connection = "iot")] IAsyncCollector<string> output,
            ILogger log)
        {
            log.LogInformation($"SetTwin function executed at: {DateTime.Now}");
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var item = new
            {
                DeviceId = data.deviceid,
                Patch = new
                {
                    properties = new
                    {
                        desired = new
                        {
                            testValue = data.testValue
                        }
                    }
                }
            };
            await output.AddAsync(JsonConvert.SerializeObject(item));
        }


        [FunctionName("GetTwin")]
        public static IActionResult GetTwin([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetTwin/{deviceid}")] HttpRequest request,
            string deviceid,
            [IoTGetDeviceTwin(Connection = "iot", DeviceId = "{deviceid}")] JObject twin,
            ILogger log)
        {
            log.LogInformation($"GetTwin function executed at: {DateTime.Now}");
            log.LogInformation($"Device Twin for {deviceid}: {twin.ToString()}");
            return new OkObjectResult(twin);
        }
    }
}
