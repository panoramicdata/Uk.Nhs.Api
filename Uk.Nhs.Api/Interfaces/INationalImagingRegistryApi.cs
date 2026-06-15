using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface INationalImagingRegistryApi
{
	/// <summary>
	/// Placeholder method for national-imaging-registry-api
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
