using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IElectronicTransmissionOfPrescriptionsWebServicesRest
{
	/// <summary>
	/// Placeholder method for electronic-transmission-of-prescriptions-web-services-rest
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
