using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface INationalDataOptOutServiceMesh
{
	/// <summary>
	/// Placeholder method for national-data-opt-out-service-mesh
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
