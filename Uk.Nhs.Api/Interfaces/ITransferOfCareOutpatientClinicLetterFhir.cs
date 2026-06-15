using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ITransferOfCareOutpatientClinicLetterFhir
{
	/// <summary>
	/// Placeholder method for transfer-of-care-outpatient-clinic-letter-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
