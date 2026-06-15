using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IInteroperabilityToolkitMessaging2Standard
{
	/// <summary>
	/// Placeholder method for interoperability-toolkit-messaging-2-standard
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
