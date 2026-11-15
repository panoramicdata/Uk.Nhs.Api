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

	/// <summary>Verifies every placeholder service sends its parameterless default call to the placeholder route.</summary>
	[Fact]
	public async Task PlaceholderServices_ParameterlessCall_RequestsPlaceholderRoute()
	{
		var placeholderTypes = typeof(NhsClient).Assembly
			.GetTypes()
			.Where(type => type.IsInterface && type.Namespace == typeof(IHelloWorld).Namespace && type.GetMethod("GetDataAsync", Type.EmptyTypes) != null)
			.ToList();
		var (handler, client) = CreateClient();
		using var _ = client;

		foreach (var interfaceType in placeholderTypes)
		{
			var api = RestService.For(interfaceType, client);
			await (Task)Invoke(api, interfaceType, "GetDataAsync")!;
		}

		placeholderTypes.Should().HaveCountGreaterThan(100);
		handler.Paths.Should().HaveCount(placeholderTypes.Count);
		handler.Paths.Should().OnlyContain(path => path == "/base/placeholder");
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
