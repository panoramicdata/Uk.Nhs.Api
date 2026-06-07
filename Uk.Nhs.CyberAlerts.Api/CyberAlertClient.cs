using Refit;
using System;
using System.Net.Http;
using Uk.Nhs.CyberAlerts.Api.Interfaces;

namespace Uk.Nhs.CyberAlerts.Api;

/// <summary>
/// Provides access to the NHS Cyber Alerts REST API.
/// </summary>
public class CyberAlertClient : IDisposable
{
	private bool disposedValue;
	private readonly HttpClient _httpClient;

	/// <summary>
	/// Initializes a new client configured for the NHS Cyber Alerts endpoint.
	/// </summary>
	public CyberAlertClient()
	{
		_httpClient = new HttpClient
		{
			BaseAddress = new Uri("https://digital.nhs.uk/restapi/CyberAlert")
		};

		CyberAlerts = RestService.For<ICyberAlerts>(_httpClient);
	}

	/// <summary>
	/// Gets the typed API contract for cyber alert operations.
	/// </summary>
	public ICyberAlerts CyberAlerts { get; }

	/// <summary>
	/// Releases managed resources used by the client.
	/// </summary>
	/// <param name="disposing"><see langword="true"/> when called from <see cref="Dispose()"/>; otherwise, <see langword="false"/>.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				_httpClient.Dispose();
			}

			disposedValue = true;
		}
	}

	/// <summary>
	/// Disposes the client and its underlying HTTP resources.
	/// </summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
