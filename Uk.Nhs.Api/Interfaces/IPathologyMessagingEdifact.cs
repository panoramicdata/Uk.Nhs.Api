using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IPathologyMessagingEdifact
{
	/// <summary>
	/// Placeholder method for pathology-messaging-edifact
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
