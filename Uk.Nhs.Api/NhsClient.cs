using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Uk.Nhs.Api.Interfaces;

namespace Uk.Nhs.Api;

public class NhsClient : IDisposable
{
	private bool disposedValue;
	private readonly List<HttpClient> _httpClients = [];

	public NhsClient(NhsClientOptions options)
	{
		// Create an HttpClientMessageHandler that can be used to add logging or other functionality
		var loggingHttpClientMessageHandler = new LoggingHandler(options.Logger);

		CyberAlerts = RestService.For<ICyberAlerts>(CreateHttpClient("https://digital.nhs.uk/restapi/CyberAlert", loggingHttpClientMessageHandler));
	}

	public ICyberAlerts CyberAlerts { get; }

	private HttpClient CreateHttpClient(string baseAddress, HttpMessageHandler? handler = null)
	{
		var httpClient = handler is null ? new HttpClient() : new HttpClient(handler);
		httpClient.BaseAddress = new Uri(baseAddress);
		_httpClients.Add(httpClient);
		return httpClient;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				foreach (var httpClient in _httpClients)
				{
					httpClient.Dispose();
				}
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
