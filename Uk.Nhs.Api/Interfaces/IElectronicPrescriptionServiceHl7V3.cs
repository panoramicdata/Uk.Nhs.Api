using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IElectronicPrescriptionServiceHl7V3
{
	/// <summary>
	/// Placeholder method for electronic-prescription-service-hl7-v3
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
