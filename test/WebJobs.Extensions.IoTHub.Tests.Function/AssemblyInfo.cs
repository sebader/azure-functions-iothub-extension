﻿using Microsoft.Azure.WebJobs.Hosting;

// Register custom extension of Function App startup
[assembly: WebJobsStartup(typeof(WebJobs.Extensions.IoTHub.Tests.Function.Startup))]