using Refit;
using System.Threading;
using System.Threading.Tasks;
using Uk.Nhs.CyberAlerts.Api.Data;

namespace Uk.Nhs.CyberAlerts.Api.Interfaces;

	/// <summary>
	/// Defines operations exposed by the NHS Cyber Alerts API.
	/// </summary>
	public interface ICyberAlerts
	{
		/// <summary>
		/// Gets a page of cyber alerts.
		/// </summary>
		/// <param name="page">The 1-based page number to retrieve.</param>
		/// <param name="limited">Set to <see langword="true"/> to request the reduced alert payload.</param>
		/// <param name="cancellationToken">The token used to cancel the request.</param>
		/// <returns>A page of alerts from the API.</returns>
		[Get("/page")]
		Task<Page<CyberAlert>> GetPageAsync(
			[AliasAs("page")] int page,
			[AliasAs("_limited")] bool limited = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// Gets a single cyber alert.
		/// </summary>
		/// <param name="threatId">The threat identifier, typically formatted like <c>AA-1111</c>.</param>
		/// <param name="limited">Set to <see langword="true"/> to request the reduced alert payload.</param>
		/// <param name="cancellationToken">Optional CancellationToken</param>
		/// <returns>The matching alert.</returns>
		[Get("/single")]
		Task<CyberAlert> GetAsync(
			[AliasAs("threatid")] string threatId,
			[AliasAs("_limited")] bool limited = false,
			CancellationToken cancellationToken = default
			);
	}
