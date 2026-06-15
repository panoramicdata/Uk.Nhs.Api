using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ISpineElectronicPrescriptionServiceTrackerRest
{
	/// <summary>
	/// Placeholder method for spine-electronic-prescription-service-tracker-rest
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
