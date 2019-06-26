using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Extensions.IoTHub.Config;

namespace WebJobs.Extensions.IoTHub.Tests.Function
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<IoTDirectMethodExtension>();
            builder.AddExtension<IoTCloudToDeviceExtension>();
            builder.AddExtension<IoTSetDeviceTwinExtension>();
            builder.AddExtension<IoTGetDeviceTwinExtension>();
        }
    }
}
