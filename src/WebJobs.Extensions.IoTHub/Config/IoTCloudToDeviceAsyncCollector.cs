using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Devices;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Extensions.IoTHub.Config
{
    public class IoTCloudToDeviceAsyncCollector : IAsyncCollector<IoTCloudToDeviceItem>
    {
        private readonly ServiceClient serviceClient;

        public IoTCloudToDeviceAsyncCollector(ServiceClient serviceClient, IoTCloudToDeviceAttribute attribute)
        {
            // create client;    
            this.serviceClient = serviceClient;
        }
        public async Task AddAsync(IoTCloudToDeviceItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            await SendCloudToDeviceMessageAsync(item);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        private async Task SendCloudToDeviceMessageAsync(IoTCloudToDeviceItem item)
        {
            char[] messageCharArr = item.Message.ToCharArray();
            var deviceToCloudMessage = new Message(Encoding.UTF8.GetBytes(messageCharArr));
            await serviceClient.SendAsync(item.DeviceId, deviceToCloudMessage);
        }
    }
}
