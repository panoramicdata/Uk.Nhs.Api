using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using Xunit;

namespace Uk.Nhs.CyberAlerts.Api.Test;

/// <summary>
/// Provides shared infrastructure for integration tests.
/// </summary>
/// <param name="testOutputHelper">The xUnit output helper for test diagnostics.</param>
public abstract class Test(ITestOutputHelper testOutputHelper) : IDisposable
{
	private bool disposedValue;

	/// <summary>
	/// Gets the xUnit output helper for the current test.
	/// </summary>
	protected ITestOutputHelper Output { get; } = testOutputHelper;

	/// <summary>
	/// Gets a logger that writes to the test output stream.
	/// </summary>
	protected ILogger Logger { get; } = new XunitLoggerProvider(testOutputHelper, LogLevel.Debug)
		.CreateLogger("Test");

	/// <summary>
	/// Gets the cancellation token supplied by the current xUnit test context.
	/// </summary>
	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	/// <summary>
	/// Gets the API client used by integration tests.
	/// </summary>
	public CyberAlertClient Client { get; } = new CyberAlertClient();

	/// <summary>
	/// Releases managed resources used by the test fixture.
	/// </summary>
	/// <param name="disposing"><see langword="true"/> when called from <see cref="Dispose()"/>; otherwise, <see langword="false"/>.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				Client.Dispose();
			}

			disposedValue = true;
		}
	}

	/// <summary>
	/// Disposes the shared test resources.
	/// </summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
