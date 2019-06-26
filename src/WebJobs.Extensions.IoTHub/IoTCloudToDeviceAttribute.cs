using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.IoTHub
{
    /// <summary>
    /// Binding attribute to place on user code for WebJobs. 
    /// </summary>
    [Binding]
    public class IoTCloudToDeviceAttribute : Attribute
    {
        /// <summary>
        /// Name of the AppSetting that contains the IoT Hub connection string, e.g. of the iothubowner
        /// </summary>
        [AppSetting]
        public string Connection { get; set; }
    }

}
