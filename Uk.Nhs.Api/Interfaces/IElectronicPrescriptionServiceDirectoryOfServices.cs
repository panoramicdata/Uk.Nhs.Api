using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IElectronicPrescriptionServiceDirectoryOfServices
{
	/// <summary>
	/// Placeholder method for electronic-prescription-service-directory-of-services
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
