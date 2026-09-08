using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ITransferOfCareMentalHealthDischargeFhir
{
	/// <summary>
	/// Placeholder method for transfer-of-care-mental-health-discharge-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for transfer-of-care-mental-health-discharge-fhir
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
