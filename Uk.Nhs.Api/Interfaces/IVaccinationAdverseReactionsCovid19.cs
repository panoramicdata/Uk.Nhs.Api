using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IVaccinationAdverseReactionsCovid19
{
	/// <summary>
	/// Placeholder method for vaccination-adverse-reactions-covid-19
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
