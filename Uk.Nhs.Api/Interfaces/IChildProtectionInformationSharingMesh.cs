using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IChildProtectionInformationSharingMesh
{
	/// <summary>
	/// Placeholder method for child-protection-information-sharing-mesh
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
