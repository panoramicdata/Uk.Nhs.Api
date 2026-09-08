using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IAmbulanceDataSubmissionFhir
{
	/// <summary>
	/// Placeholder method for ambulance-data-submission-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for ambulance-data-submission-fhir
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
