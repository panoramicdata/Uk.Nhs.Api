using Refit;
using Uk.Nhs.Api.CyberAlerts;
using Uk.Nhs.Api.Interfaces;

namespace Uk.Nhs.Api.Test.Offline;

/// <summary>Offline tests that drive the Cyber Alerts interface through the logging handler against a loopback stub.</summary>
public class CyberAlertsEndpointTests
{
	private const string PageJson = "{\"pageSize\":10,\"total\":1,\"items\":[{\"threatId\":\"CC-1\",\"publishedDate\":1700000000000,\"title\":\"A title\",\"severity\":\"High\",\"cveIdentifiers\":[{\"cveIdentifier\":\"CVE-2026-0001\",\"cveStatus\":\"Published\",\"cveText\":\"text\"}],\"sections\":[{\"title\":\"S\",\"html\":\"<p>x</p>\"}]}],\"totalPages\":1,\"currentPage\":1}";
	private const string SingleJson = "{\"threatId\":\"CC-7\",\"threatType\":\"Vulnerability\",\"versionedNode\":true,\"category\":[\"a\",\"b\"]}";

	private static ICyberAlerts CreateApi(StubServer server, ILogger logger, out HttpClient httpClient)
	{
		httpClient = new HttpClient(new LoggingHandler(logger)) { BaseAddress = server.BaseAddress };
		return RestService.For<ICyberAlerts>(httpClient);
	}

	/// <summary>Verifies the page request honours the limited flag and builds the page endpoint with the expected query.</summary>
	[Theory]
	[InlineData(false, "/restapi/CyberAlert/page?page=3&_limited=False")]
	[InlineData(true, "/restapi/CyberAlert/page?page=3&_limited=True")]
	public async Task GetPage_WithLimitedFlag_RequestsPageEndpoint(bool limited, string expectedPathAndQuery)
	{
		using var server = new StubServer(PageJson);
		var api = CreateApi(server, new CapturingLogger(), out var httpClient);
		using var _ = httpClient;
		var token = TestContext.Current.CancellationToken;

		var page = await api.GetPageAsync(3, limited, token);

		server.LastPathAndQuery.Should().Be(expectedPathAndQuery);
		page.Items.Should().ContainSingle().Which.ThreatId.Should().Be("CC-1");
		page.PageSize.Should().Be(10);
		page.TotalPages.Should().Be(1);
		page.CurrentPage.Should().Be(1);
	}

	/// <summary>Verifies the single alert request honours the limited flag and builds the single endpoint with the expected query.</summary>
	[Theory]
	[InlineData(false, "/restapi/CyberAlert/single?threatid=CC-7&_limited=False")]
	[InlineData(true, "/restapi/CyberAlert/single?threatid=CC-7&_limited=True")]
	public async Task Get_WithLimitedFlag_RequestsSingleEndpoint(bool limited, string expectedPathAndQuery)
	{
		using var server = new StubServer(SingleJson);
		var api = CreateApi(server, new CapturingLogger(), out var httpClient);
		using var _ = httpClient;
		var token = TestContext.Current.CancellationToken;

		var alert = await api.GetAsync("CC-7", limited, token);

		server.LastPathAndQuery.Should().Be(expectedPathAndQuery);
		alert.ThreatId.Should().Be("CC-7");
		alert.ThreatType.Should().Be("Vulnerability");
		alert.VersionedNode.Should().BeTrue();
		alert.Category.Should().Equal("a", "b");
	}

	/// <summary>Verifies the token-only overloads default the limited flag to false.</summary>
	[Fact]
	public async Task TokenOnlyOverloads_DefaultToFullAlerts()
	{
		using var server = new StubServer(PageJson);
		var api = CreateApi(server, new CapturingLogger(), out var httpClient);
		using var _ = httpClient;
		var token = TestContext.Current.CancellationToken;

		await api.GetPageAsync(2, token);
		var pagePath = server.LastPathAndQuery;
		await api.GetAsync("CC-9", token);

		pagePath.Should().Be("/restapi/CyberAlert/page?page=2&_limited=False");
		server.LastPathAndQuery.Should().Be("/restapi/CyberAlert/single?threatid=CC-9&_limited=False");
	}

	/// <summary>Verifies nested alert content is mapped onto the model types.</summary>
	[Fact]
	public async Task GetPage_MapsNestedContent()
	{
		using var server = new StubServer(PageJson);
		var api = CreateApi(server, new CapturingLogger(), out var httpClient);
		using var _ = httpClient;

		var page = await api.GetPageAsync(1, TestContext.Current.CancellationToken);

		var alert = page.Items.Single();
		alert.Title.Should().Be("A title");
		alert.Severity.Should().Be("High");
		alert.PublishedDate.Should().Be(1700000000000);
		alert.Sections.Should().ContainSingle().Which.Html.Should().Be("<p>x</p>");
		alert.CveIdentifiers.Should().ContainSingle().Which.CveStatus.Should().Be("Published");
	}

	/// <summary>Verifies a failure status surfaces as a Refit exception.</summary>
	[Fact]
	public async Task Get_WithFailureStatus_Throws()
	{
		using var server = new StubServer("{}", statusCode: 403);
		var api = CreateApi(server, new CapturingLogger(), out var httpClient);
		using var _ = httpClient;

		var act = () => api.GetAsync("CC-1", TestContext.Current.CancellationToken);

		var exception = await act.Should().ThrowAsync<ApiException>();
		exception.Which.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
	}

	/// <summary>Verifies the handler logs the request and the response body at debug level.</summary>
	[Fact]
	public async Task LoggingHandler_LogsRequestAndResponseAtDebug()
	{
		using var server = new StubServer(SingleJson);
		var logger = new CapturingLogger();
		var api = CreateApi(server, logger, out var httpClient);
		using var _ = httpClient;

		await api.GetAsync("CC-7", TestContext.Current.CancellationToken);

		logger.Messages.Should().Contain(message => message.StartsWith("Sending HTTP request: GET", StringComparison.Ordinal) && message.Contains("threatid=CC-7"));
		logger.Messages.Should().Contain(message => message.StartsWith("Received HTTP response: OK", StringComparison.Ordinal) && message.Contains("Vulnerability"));
	}

	/// <summary>Verifies the handler logs nothing when debug logging is off.</summary>
	[Fact]
	public async Task LoggingHandler_WhenDebugDisabled_LogsNothing()
	{
		using var server = new StubServer(SingleJson);
		var logger = new CapturingLogger(LogLevel.Warning);
		var api = CreateApi(server, logger, out var httpClient);
		using var _ = httpClient;

		await api.GetAsync("CC-7", TestContext.Current.CancellationToken);

		logger.Messages.Should().BeEmpty();
	}
}
