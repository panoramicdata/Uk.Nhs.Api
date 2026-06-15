using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IDigitalStaffPassportApiStandard
{
	/// <summary>
	/// Placeholder method for digital-staff-passport-api-standard
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
