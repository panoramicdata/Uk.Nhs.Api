using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ILegitimateRelationshipServiceHl7V3
{
	/// <summary>
	/// Placeholder method for legitimate-relationship-service-hl7-v3
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
