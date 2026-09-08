using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IAddressQualityService
{
	/// <summary>
	/// Placeholder method for address-quality-service
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for address-quality-service
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}

