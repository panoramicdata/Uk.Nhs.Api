using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface ILogicalRecordArchitectureApiStandards
{
	/// <summary>
	/// Placeholder method for logical-record-architecture-api-standards
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
