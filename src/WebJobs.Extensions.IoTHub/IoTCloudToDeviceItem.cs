using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.IoTHub
{
    public class IoTCloudToDeviceItem
    {
        // IoT DeviceId
        public string DeviceId { set; get; }

        // Messege sent from device to cloud
        public string Message { set; get; }
    }
}
