using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IPatientCareAggregatorReporting
{
	/// <summary>
	/// Placeholder method for patient-care-aggregator-reporting
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for patient-care-aggregator-reporting
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
