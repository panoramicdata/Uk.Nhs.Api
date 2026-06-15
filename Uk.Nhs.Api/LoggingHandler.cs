using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api;

internal class LoggingHandler(ILogger logger) : HttpClientHandler
{
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (logger.IsEnabled(LogLevel.Debug))
		{
			logger.LogDebug(
				"Sending HTTP request: {Method} {RequestUri}",
				request.Method,
				request.RequestUri);
		}

		var response = await base.SendAsync(request, cancellationToken);

		if (logger.IsEnabled(LogLevel.Debug))
		{
			var body = response.Content != null
				? await response
					.Content
					.ReadAsStringAsync(cancellationToken)
				: string.Empty;

			logger.LogDebug(
				"Received HTTP response: {StatusCode} for {Method} {RequestUri}: {Body}",
				response.StatusCode,
				request.Method,
				request.RequestUri,
				body);
		}

		return response;
	}
}