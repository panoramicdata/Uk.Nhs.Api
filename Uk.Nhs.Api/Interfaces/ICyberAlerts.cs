using Refit;
using System.Threading;
using System.Threading.Tasks;
using Uk.Nhs.Api.CyberAlerts;

namespace Uk.Nhs.Api.Interfaces;

public interface ICyberAlerts
{
	/// <summary>
	/// Gets a page of Cyber Alerts
	/// </summary>
	/// <param name="page">The page number</param>
	/// <param name="limited">To return only the basic details of the alert, you can use the optional limited modifier</param>
	/// <param name="cancellationToken"></param>
	/// <returns>A page of alerts</returns>
	[Get("/page")]
	Task<Page<CyberAlert>> GetPageAsync(
		[AliasAs("page")] int page,
		[AliasAs("_limited")] bool limited,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Gets a page of Cyber Alerts
	/// </summary>
	/// <param name="page">The page number</param>
	/// <returns>A page of alerts</returns>
	Task<Page<CyberAlert>> GetPageAsync(int page)
		=> GetPageAsync(page, limited: false, CancellationToken.None);

	/// <summary>
	/// Gets a page of Cyber Alerts
	/// </summary>
	/// <param name="page">The page number</param>
	/// <param name="limited">To return only the basic details of the alert, you can use the optional limited modifier</param>
	/// <returns>A page of alerts</returns>
	Task<Page<CyberAlert>> GetPageAsync(int page, bool limited)
		=> GetPageAsync(page, limited, CancellationToken.None);

	/// <summary>
	/// Gets a page of Cyber Alerts
	/// </summary>
	/// <param name="page">The page number</param>
	/// <param name="cancellationToken"></param>
	/// <returns>A page of alerts</returns>
	Task<Page<CyberAlert>> GetPageAsync(int page, CancellationToken cancellationToken)
		=> GetPageAsync(page, limited: false, cancellationToken);

	/// <summary>
	/// Gets a single Cyber Alert
	/// </summary>
	/// <param name="threatId">You must specify a threat ID, normally formatted AA-1111</param>
	/// <param name="limited">To return only the basic details of the alert, you can use the optional limited modifier</param>
	/// <param name="cancellationToken">Optional CancellationToken</param>
	/// <returns>A single alert</returns>
	[Get("/single")]
	Task<CyberAlert> GetAsync(
		[AliasAs("threatid")] string threatId,
		[AliasAs("_limited")] bool limited,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Gets a single Cyber Alert
	/// </summary>
	/// <param name="threatId">You must specify a threat ID, normally formatted AA-1111</param>
	/// <returns>A single alert</returns>
	Task<CyberAlert> GetAsync(string threatId)
		=> GetAsync(threatId, limited: false, CancellationToken.None);

	/// <summary>
	/// Gets a single Cyber Alert
	/// </summary>
	/// <param name="threatId">You must specify a threat ID, normally formatted AA-1111</param>
	/// <param name="limited">To return only the basic details of the alert, you can use the optional limited modifier</param>
	/// <returns>A single alert</returns>
	Task<CyberAlert> GetAsync(string threatId, bool limited)
		=> GetAsync(threatId, limited, CancellationToken.None);

	/// <summary>
	/// Gets a single Cyber Alert
	/// </summary>
	/// <param name="threatId">You must specify a threat ID, normally formatted AA-1111</param>
	/// <param name="cancellationToken">Optional CancellationToken</param>
	/// <returns>A single alert</returns>
	Task<CyberAlert> GetAsync(string threatId, CancellationToken cancellationToken)
		=> GetAsync(threatId, limited: false, cancellationToken);
}
