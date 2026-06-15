namespace Uk.Nhs.Api.Test;

public abstract class Test : IDisposable
{
	private bool disposedValue;

	protected ILogger Logger { get; }

	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	protected NhsClient Client { get; }

	protected Test(ITestOutputHelper testOutputHelper)
	{
		Logger = new XunitLoggerProvider(testOutputHelper, LogLevel.Debug).CreateLogger("Test");
		Client = new NhsClient(new NhsClientOptions { Logger = Logger });
	}

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

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
