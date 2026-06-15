using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IIntegratedUrgentCareDomainMessageSpecification
{
	/// <summary>
	/// Placeholder method for integrated-urgent-care-domain-message-specification
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
