using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using System.Threading;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.IoTHub.Config
{
    public class IoTDirectMethodAsyncCollector : IAsyncCollector<IoTDirectMethodItem>
    {
        private readonly ServiceClient serviceClient;
        private readonly int timeout;

        public IoTDirectMethodAsyncCollector(ServiceClient serviceClient, IoTDirectMethodAttribute attribute)
        {
            this.serviceClient = serviceClient;
            this.timeout = attribute.DirectMethodTimeout;
        }

        public async Task AddAsync(IoTDirectMethodItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            await InvokeMethod(item, cancellationToken);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        private async Task InvokeMethod(IoTDirectMethodItem item, CancellationToken cancellationToken)
        {
            var methodInvocation = new CloudToDeviceMethod(item.MethodName) { ResponseTimeout = TimeSpan.FromSeconds(this.timeout) };
            methodInvocation.SetPayloadJson(item.Payload);

            // If the module name is set, make a direct method call against an Edge module
            if (!string.IsNullOrEmpty(item.ModuleName))
            {
                var response = await serviceClient.InvokeDeviceMethodAsync(item.DeviceId, item.ModuleName, methodInvocation, cancellationToken);
            }
            else
            {
                var response = await serviceClient.InvokeDeviceMethodAsync(item.DeviceId, methodInvocation, cancellationToken);
            }
        }
    }
}
