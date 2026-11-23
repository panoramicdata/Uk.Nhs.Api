[![Codacy Badge](https://app.codacy.com/project/badge/Grade/d22981b9593b43839e91078bd3d06a10)](https://app.codacy.com/gh/panoramicdata/Uk.Nhs.Api/dashboard)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

# Uk.Nhs.Api

> **Need help with APIs or .NET?** Panoramic Data are experts in APIs and .NET, and we can help with your development. [Contact us](https://www.panoramicdata.com/contact-us) or see our [software services](https://www.panoramicdata.com/services/software).

A .NET client for the NHS England Cyber Alerts API.

Supports .NET 11.0.

[![Nuget](https://img.shields.io/nuget/v/Uk.Nhs.Api)](https://www.nuget.org/packages/Uk.Nhs.Api/)

## Usage

```C#
using Uk.Nhs.Api;

...

using var client = new NhsClient(new NhsClientOptions());

// Get the first page of alerts
var alertsPage = await client
	.CyberAlerts
	.GetPageAsync(1)
	.ConfigureAwait(false);

// Get a single alert
var alert = await client
	.CyberAlerts
	.GetAsync("CC-3327")
	.ConfigureAwait(false);
```

## Breaking changes

This package previously exposed one service interface and `NhsClient` property for each API in the NHS API catalogue. All but Cyber Alerts were placeholders that pointed at a non-existent address and could never return data. They have been removed:

- All service interfaces in the `Uk.Nhs.Api.Interfaces` namespace other than `ICyberAlerts`, including `IHelloWorld`.
- The matching service properties on `NhsClient`, for example `AddressQualityService`, `AccessControlService` and `AlertsHl7V3`. `NhsClient.CyberAlerts` is now the only service property.

If your code referenced any of the removed members, remove those references: they never worked. Code that only uses `NhsClient.CyberAlerts` is unaffected.