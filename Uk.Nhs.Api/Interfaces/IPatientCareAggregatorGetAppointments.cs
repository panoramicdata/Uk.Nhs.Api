using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IPatientCareAggregatorGetAppointments
{
	/// <summary>
	/// Placeholder method for patient-care-aggregator-get-appointments
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
