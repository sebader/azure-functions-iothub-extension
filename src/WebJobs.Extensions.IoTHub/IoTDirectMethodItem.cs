using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.IoTHub
{
    public class IoTDirectMethodItem
    {
        // Destination IoT DeviceId
        public string DeviceId { set; get; }

        // MethodName to be invoked
        public string MethodName { set; get; }
        
        /// <summary>
        /// Payload to the direct method. Needs to be a JSON as string
        /// </summary>
        public string Payload { set; get; }
    }
}
