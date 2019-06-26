using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.IoTHub
{
    /// <summary>
    /// Binding attribute to place on user code for WebJobs. 
    /// </summary>
    [Binding]
    public class IoTDirectMethodAttribute : Attribute
    {
        /// <summary>
        /// Name of the AppSetting that contains the IoT Hub connection string, e.g. of the iothubowner
        /// </summary>
        [AppSetting]
        public string Connection { get; set; }

        /// <summary>
        /// Timeout in seconds for the direct method calls. Default is 30 seconds
        /// </summary>
        public int DirectMethodTimeout { get; set; } = 30;
    }
}
