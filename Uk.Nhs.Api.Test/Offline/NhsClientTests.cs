using Microsoft.Extensions.Logging.Abstractions;

namespace Uk.Nhs.Api.Test.Offline;

/// <summary>Offline tests for client construction and disposal; nothing here sends a request.</summary>
public class NhsClientTests
{
	/// <summary>Verifies the service properties on the client are populated.</summary>
	[Fact]
	public void Constructor_PopulatesEveryServiceProperty()
	{
		using var client = new NhsClient(new NhsClientOptions());

		var serviceProperties = typeof(NhsClient)
			.GetProperties()
			.Where(property => property.PropertyType.IsInterface)
			.ToList();

		serviceProperties.Should().ContainSingle(property => property.PropertyType == typeof(Uk.Nhs.Api.Interfaces.ICyberAlerts));
		serviceProperties.Should().OnlyContain(property => property.GetValue(client) != null);
	}

	/// <summary>Verifies the options default to a logger that discards output.</summary>
	[Fact]
	public void Options_DefaultToNullLogger()
		=> new NhsClientOptions().Logger.Should().BeSameAs(NullLogger.Instance);

	/// <summary>Verifies the client can be disposed repeatedly.</summary>
	[Fact]
	public void Dispose_CanBeCalledTwice()
	{
		var client = new NhsClient(new NhsClientOptions());

		client.Dispose();
		var act = client.Dispose;

		act.Should().NotThrow();
	}
}
