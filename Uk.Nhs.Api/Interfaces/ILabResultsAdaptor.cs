using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ILabResultsAdaptor
{
	/// <summary>
	/// Placeholder method for lab-results-adaptor
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for lab-results-adaptor
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
