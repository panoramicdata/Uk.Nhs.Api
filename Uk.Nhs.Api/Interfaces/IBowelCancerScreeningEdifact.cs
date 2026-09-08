using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IBowelCancerScreeningEdifact
{
	/// <summary>
	/// Placeholder method for bowel-cancer-screening-edifact
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for bowel-cancer-screening-edifact
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
