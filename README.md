![MTConnect.NET Logo] (http://trakhound.com/images/mtconnect-net-logo.png)

[![NuGet](https://img.shields.io/nuget/v/MTConnect.Net.svg?style=flat-square)](https://www.nuget.org/packages/MTConnect.NET/) [![Hex.pm](https://img.shields.io/hexpm/l/plug.svg?style=flat-square)](https://www.apache.org/licenses/LICENSE-2.0)

MTConnect.NET is a .NET library for the [MTConnect®](http://www.mtconnect.org) protocol for machine tool data collection. Uses the .NET XmlSerializer to parse and easy to use functions for requesting data from MTConnect Agents. Supports up to MTConnect v1.3.

# Features
- Easy to use client classes
- Full MTConnect document responses as class objects
- Intellisense using text directly from the MTConnect Standard
- Simple parsing using built in XmlSerializer

# Installation

## Nuget
**PM> Install-Package MTConnect.NET**

http://www.nuget.org/packages/MTConnect.NET/

# Examples

## MTConnectClient
The MTConnectClient class handles the entire request structure for a typical data collection application using MTConnect. First a Probe request is made, then a Current request, then a stream is opened for any new Sample data. The class will continue to run until the Stop() method is called and will handle errors internally.

```c#
using MTConnect;
using MTConnect.Client;

MTConnectClient client;

void Start()
{
  // The base address for the MTConnect Agent
  string baseUrl = "http://agent.mtconnect.org";

  // Create a new MTConnectClient using the baseUrl
  client = new MTConnectClient(baseUrl);

  // Subscribe to the Event handlers to receive the MTConnect documents
  client.ProbeReceived += Probe_Successful;
  client.CurrentReceived += Current_Successful;
  client.SampleReceived += Current_Successful;

  // Start the MTConnectClient
  client.Start();
}

void Stop()
{
  client.Stop();
}

// --- Event Handlers ---

void DevicesSuccessful(MTConnectDevices.Document document)
{
  foreach (var device in document.Devices)
  {
     var dataItems = device.GetDataItems();
     foreach (var dataItem in dataItems) Console.WriteLine(dataItem.Id + " : " + dataItem.Name);
  }
}

void StreamsSuccessful(MTConnectStreams.Document document)
{
  foreach (var deviceStream in document.DeviceStreams)
  {
     foreach (var dataItem in deviceStream.DataItems) Console.WriteLine(dataItem.DataItemId + " = " + dataItem.CDATA);
  }
}

```

### Components.Requests Example

```c#
// Create Request URL for Probe Request
string url = MTConnect.HTTP.GetUrl("127.0.0.1", 5000, "VMC-3Axis") + "probe";

// Get ReturnData object back that contains a hierarchical object with the retrieved Current data 
var returnData = MTConnect.Components.Requests.Get(url, 2000, 1);
```

### Streams.Requests Example

```c#
// Create Request URL for Current Request
string url = MTConnect.HTTP.GetUrl("127.0.0.1", 5000, "VMC-3Axis") + "current";

// Get ReturnData object back that contains a hierarchical object with the retrieved Probe data 
var returnData = MTConnect.Streams.Requests.Get(url, 2000, 1);
```

## License
This library is licensed under the Apache 2.0 License
