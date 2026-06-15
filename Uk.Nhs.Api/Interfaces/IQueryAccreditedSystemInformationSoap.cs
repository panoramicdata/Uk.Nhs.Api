using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IQueryAccreditedSystemInformationSoap
{
	/// <summary>
	/// Placeholder method for query-accredited-system-information-soap
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
