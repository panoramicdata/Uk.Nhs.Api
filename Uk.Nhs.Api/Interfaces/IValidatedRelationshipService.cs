using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IValidatedRelationshipService
{
	/// <summary>
	/// Placeholder method for validated-relationship-service
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for validated-relationship-service
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
