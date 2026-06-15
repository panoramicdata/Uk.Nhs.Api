using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IGpConnectAccessRecordHtmlFhir
{
	/// <summary>
	/// Placeholder method for gp-connect-access-record-html-fhir
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
