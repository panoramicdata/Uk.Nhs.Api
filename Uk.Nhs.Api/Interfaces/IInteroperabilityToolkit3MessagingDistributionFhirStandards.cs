using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IInteroperabilityToolkit3MessagingDistributionFhirStandards
{
	/// <summary>
	/// Placeholder method for interoperability-toolkit-3-messaging-distribution-fhir-standards
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
