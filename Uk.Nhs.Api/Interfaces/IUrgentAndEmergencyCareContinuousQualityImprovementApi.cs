using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IUrgentAndEmergencyCareContinuousQualityImprovementApi
{
	/// <summary>
	/// Placeholder method for urgent-and-emergency-care-continuous-quality-improvement-api
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
