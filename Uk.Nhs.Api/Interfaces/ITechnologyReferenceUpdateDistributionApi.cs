using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ITechnologyReferenceUpdateDistributionApi
{
	/// <summary>
	/// Placeholder method for technology-reference-update-distribution-api
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
