using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface INationalEarlyWarningScore2Standards
{
	/// <summary>
	/// Placeholder method for national-early-warning-score-2-standards
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
