[![Codacy Badge](https://app.codacy.com/project/badge/grade/Uk.Nhs.Api)](https://app.codacy.com/gh/panoramicdata/Uk.Nhs.Api/dashboard)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

[![Codacy Badge](https://app.codacy.com/project/badge/grade/Uk.Nhs.CyberAlerts.Api)](https://app.codacy.com/gh/panoramicdata/Uk.Nhs.CyberAlerts.Api/dashboard)

# Uk.Nhs.CyberAlerts.Api

> **Need help with APIs or .NET?** Panoramic Data are experts in APIs and .NET, and we can help with your development. [Contact us](https://www.panoramicdata.com/contact-us) or see our [software services](https://www.panoramicdata.com/services/software).

A Nuget package for the UK NHS Cyber Alerts.

Supports .NET 11.0.

[![Nuget](https://img.shields.io/nuget/v/Uk.Nhs.CyberAlerts.Api)](https://www.nuget.org/packages/Uk.Nhs.CyberAlerts.Api/)

To use:

```C#
using Uk.Nhs.CyberAlerts.Api;

...

using var client = new CyberAlertClient();

// Get the first page of 10 alerts
var alertsPage = await client
	.GetPageAsync(1)
	.ConfigureAwait(false);

// Get a single alert
var alert = await client
	.GetAsync("CC-3327")
	.ConfigureAwait(false);
