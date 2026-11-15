using System.Text.Json;
using Uk.Nhs.Api.CyberAlerts;

namespace Uk.Nhs.Api.Test.Offline;

/// <summary>Offline tests for the Cyber Alerts model types.</summary>
public class ModelTests
{
	private static readonly JsonSerializerOptions Web = new(JsonSerializerDefaults.Web);

	/// <summary>Verifies the optional properties of a new alert are unset.</summary>
	[Fact]
	public void CyberAlert_NewInstance_HasNoValues()
	{
		var alert = new CyberAlert();

		alert.ThreatId.Should().BeNull();
		alert.Sections.Should().BeNull();
		alert.PublishedDate.Should().Be(0);
		alert.VersionedNode.Should().BeFalse();
	}

	/// <summary>Verifies the supporting types round trip their values.</summary>
	[Fact]
	public void SupportingTypes_RoundTripValues()
	{
		var threatAffect = new ThreatAffect { PlatformText = "Windows", VersionsAffected = ["10", "11"], Leaf = true };
		var step = new RemediationStep { Step = "Patch", Link = "https://example.test", Type = "link" };
		var indicator = new IndicatorsCompromise { Heading = "IoC", Content = "1.2.3.4", Audience = "all" };
		var cve = new CveIdentifier { Id = "CVE-1", CveStatus = "Published", CveText = "text" };

		threatAffect.VersionsAffected.Should().Equal("10", "11");
		JsonSerializer.Serialize(step, Web).Should().Contain("\"step\":\"Patch\"");
		indicator.Content.Should().Be("1.2.3.4");
		cve.Id.Should().Be("CVE-1");
	}

	/// <summary>Verifies a page requires its members and carries its items.</summary>
	[Fact]
	public void Page_CarriesItems()
	{
		var page = new Page<string> { PageSize = 2, Total = 3, Items = ["a", "b"], TotalPages = 2, CurrentPage = 1 };

		page.Items.Should().Equal("a", "b");
		page.Total.Should().Be(3);
	}
}
