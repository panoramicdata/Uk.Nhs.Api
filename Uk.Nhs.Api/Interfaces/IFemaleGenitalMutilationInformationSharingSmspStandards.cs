using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IFemaleGenitalMutilationInformationSharingSmspStandards
{
	/// <summary>
	/// Placeholder method for female-genital-mutilation---information-sharing-smsp-standards
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
