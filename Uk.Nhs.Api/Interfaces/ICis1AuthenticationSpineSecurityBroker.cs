using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ICis1AuthenticationSpineSecurityBroker
{
	/// <summary>
	/// Placeholder method for cis1-authentication-spine-security-broker
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
