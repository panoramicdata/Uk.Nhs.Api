using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Uk.Nhs.Api;

public class NhsClientOptions
{
	public ILogger Logger { get; init; } = NullLogger.Instance;
}