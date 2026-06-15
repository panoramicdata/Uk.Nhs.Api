using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IReasonableAdjustmentFlagFhir
{
	/// <summary>
	/// Placeholder method for reasonable-adjustment-flag-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
