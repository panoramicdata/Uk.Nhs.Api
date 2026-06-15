using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ITransferOfCareEmergencyCareDischargeFhir
{
	/// <summary>
	/// Placeholder method for transfer-of-care-emergency-care-discharge-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
