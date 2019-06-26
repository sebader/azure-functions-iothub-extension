### IoTHub Extension

Fully featured IoT Hub input and output bindings to Azure IoT Hub, allowing common interactions between cloud and devices to be done from Azure Functions. Common scenarios currently supported are: 
  * Cloud to Device: output binding that sends messages from Azure Functions to IoTHub, which then transfer the messages to specified device id in the message structure
  * Direct Method: output binding that invokes methods in the device from Azure Functions
  * Set Device Twin: output binding that updates desired properties of specified device from Azure Functions
  * Get Device Twin: input binding that gets device twin of the specified device once the Function's trigger is fired

#### Sample Code

[functions folders](https://github.com/sebader/azure-functions-iothub-extension/blob/master/test/WebJobs.Extensions.IoTHub.Tests.Function/Functions.cs) contains functions to use in Azure Functions - either in local debugging or in the cloud. To run, do the following:

> Direct Method assumes that the device has a method matched with the specified method's name given in the argument. Otherwise, Function throws an exception. 

> Executing direct method that takes longer than the lifetime of a Function (5 minutes by default and can be set up to 10 minutes) can never be completed.

## License

This project is under the benevolent umbrella of the [.NET Foundation](http://www.dotnetfoundation.org/) and is licensed under [the MIT License](https://github.com/Azure/azure-webjobs-sdk/blob/master/LICENSE.txt)

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.