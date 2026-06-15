using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IAssessmentDischargeAndWithdrawalFhir
{
	/// <summary>
	/// Placeholder method for assessment-discharge-and-withdrawal-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
