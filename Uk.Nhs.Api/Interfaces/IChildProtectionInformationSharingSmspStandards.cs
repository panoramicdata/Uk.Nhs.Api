using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IChildProtectionInformationSharingSmspStandards
{
	/// <summary>
	/// Placeholder method for child-protection---information-sharing-smsp-standards
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Placeholder method for child-protection---information-sharing-smsp-standards
	/// </summary>
	Task<string?> GetDataAsync() => GetDataAsync(CancellationToken.None);
}
