using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IGeneralPracticeExtractionServiceMesh
{
	/// <summary>
	/// Placeholder method for general-practice-extraction-service-mesh
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
