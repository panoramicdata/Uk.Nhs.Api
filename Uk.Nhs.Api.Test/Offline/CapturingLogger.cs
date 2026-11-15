namespace Uk.Nhs.Api.Test.Offline;

/// <summary>A logger that keeps every formatted message, and can have debug logging switched off.</summary>
internal sealed class CapturingLogger(LogLevel minimumLevel = LogLevel.Debug) : ILogger
{
	/// <summary>Gets the captured messages in the order they were written.</summary>
	public List<string> Messages { get; } = [];

	public IDisposable? BeginScope<TState>(TState state) where TState : notnull
		=> null;

	public bool IsEnabled(LogLevel logLevel)
		=> logLevel >= minimumLevel;

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		=> Messages.Add(formatter(state, exception));
}
