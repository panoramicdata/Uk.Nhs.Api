using System.Net;
using System.Text;

namespace Uk.Nhs.Api.Test.Offline;

/// <summary>A loopback HTTP server that returns one canned response and records the request it received.</summary>
internal sealed class StubServer : IDisposable
{
	private readonly HttpListener _listener = new();
	private readonly Task _loop;
	private readonly string _body;
	private readonly int _statusCode;

	/// <summary>Gets the base address of the stub.</summary>
	public Uri BaseAddress { get; }

	/// <summary>Gets the path and query of the most recent request.</summary>
	public string? LastPathAndQuery { get; private set; }

	/// <summary>Starts a stub that answers every request with the supplied JSON body and status.</summary>
	public StubServer(string body, int statusCode = 200)
	{
		_body = body;
		_statusCode = statusCode;

		var probe = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
		probe.Start();
		var port = ((IPEndPoint)probe.LocalEndpoint).Port;
		probe.Stop();

		var prefix = $"http://127.0.0.1:{port}/";
		_listener.Prefixes.Add(prefix);
		_listener.Start();
		BaseAddress = new Uri(prefix + "restapi/CyberAlert");
		_loop = Task.Run(ServeAsync);
	}

	private async Task ServeAsync()
	{
		while (_listener.IsListening)
		{
			HttpListenerContext context;
			try
			{
				context = await _listener.GetContextAsync();
			}
			catch (Exception exception) when (exception is HttpListenerException or ObjectDisposedException)
			{
				return;
			}

			LastPathAndQuery = context.Request.Url!.PathAndQuery;
			var bytes = Encoding.UTF8.GetBytes(_body);
			context.Response.StatusCode = _statusCode;
			context.Response.ContentType = "application/json";
			await context.Response.OutputStream.WriteAsync(bytes);
			context.Response.Close();
		}
	}

	/// <summary>Stops the server.</summary>
	public void Dispose()
	{
		_listener.Close();
		_loop.GetAwaiter().GetResult();
	}
}
