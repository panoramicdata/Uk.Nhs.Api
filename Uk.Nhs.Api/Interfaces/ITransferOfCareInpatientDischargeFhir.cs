using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ITransferOfCareInpatientDischargeFhir
{
	/// <summary>
	/// Placeholder method for transfer-of-care-inpatient-discharge-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
