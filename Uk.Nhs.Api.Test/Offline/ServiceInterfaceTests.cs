using Refit;
using Uk.Nhs.Api.Interfaces;

namespace Uk.Nhs.Api.Test.Offline;

/// <summary>Offline tests for the default interface methods, using an in-memory handler so nothing reaches a network.</summary>
public class ServiceInterfaceTests
{
	private sealed class RecordingHandler : HttpMessageHandler
	{
		public List<string> Paths { get; } = [];

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			Paths.Add(request.RequestUri!.PathAndQuery);
			return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
			{
				Content = new StringContent("{\"pageSize\":1,\"total\":0,\"items\":[],\"totalPages\":0,\"currentPage\":1}", System.Text.Encoding.UTF8, "application/json")
			});
		}
	}

	private static (RecordingHandler Handler, HttpClient Client) CreateClient()
	{
		var handler = new RecordingHandler();
		return (handler, new HttpClient(handler) { BaseAddress = new Uri("https://service.test/base") });
	}

	private static object? Invoke(object api, Type interfaceType, string methodName, params object[] arguments)
	{
		var method = interfaceType.GetMethod(methodName, [.. arguments.Select(argument => argument.GetType())])!;
		return method.Invoke(api, arguments);
	}

	/// <summary>Verifies the Cyber Alerts overloads without a cancellation token forward to the full call.</summary>
	[Fact]
	public async Task CyberAlerts_OverloadsWithoutToken_ForwardToFullCall()
	{
		var (handler, client) = CreateClient();
		using var _ = client;
		var api = RestService.For<ICyberAlerts>(client);
		var type = typeof(ICyberAlerts);

		await Task.WhenAll(
			(Task)Invoke(api, type, nameof(ICyberAlerts.GetPageAsync), 4)!,
			(Task)Invoke(api, type, nameof(ICyberAlerts.GetPageAsync), 4, true)!,
			(Task)Invoke(api, type, nameof(ICyberAlerts.GetAsync), "CC-2")!,
			(Task)Invoke(api, type, nameof(ICyberAlerts.GetAsync), "CC-2", true)!);

		handler.Paths.Should().BeEquivalentTo(
			"/base/page?page=4&_limited=False",
			"/base/page?page=4&_limited=True",
			"/base/single?threatid=CC-2&_limited=False",
			"/base/single?threatid=CC-2&_limited=True");
	}
}
