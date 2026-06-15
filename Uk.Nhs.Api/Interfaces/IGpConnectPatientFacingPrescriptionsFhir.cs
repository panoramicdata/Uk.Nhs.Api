using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IGpConnectPatientFacingPrescriptionsFhir
{
	/// <summary>
	/// Placeholder method for gp-connect-patient-facing-prescriptions-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
