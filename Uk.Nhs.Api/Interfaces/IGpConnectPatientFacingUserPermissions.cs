using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IGpConnectPatientFacingUserPermissions
{
	/// <summary>
	/// Placeholder method for gp-connect-patient-facing-user-permissions
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
