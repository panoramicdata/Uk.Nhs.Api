using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Uk.Nhs.CyberAlerts.Api.Test;

/// <summary>
/// Integration tests covering the cyber alerts API client.
/// </summary>
/// <param name="testOutputHelper">The xUnit output helper for test diagnostics.</param>
public class CyberAlertTests(ITestOutputHelper testOutputHelper) : Test(testOutputHelper)
{
	/// <summary>
	/// Verifies that a single alert can be retrieved by threat identifier.
	/// </summary>
	[Fact]
	public async Task GetSingle_Works()
	{
		const string requestedThreatId = "CC-3327";

		var alert = await Client
			.CyberAlerts
			.GetAsync(requestedThreatId, cancellationToken: CancellationToken);

		alert.Should().NotBeNull();
		alert.ThreatId.Should().Be(requestedThreatId);
	}

	/// <summary>
	/// Verifies that a paged list of alerts can be retrieved.
	/// </summary>
	[Fact]
	public async Task GetPage_Works()
	{
		var page = await Client
			.CyberAlerts
			.GetPageAsync(1, cancellationToken: CancellationToken);

		page.Should().NotBeNull();
		page.PageSize.Should().Be(10);
		page.Total.Should().BeGreaterThan(1000);
	}
}
