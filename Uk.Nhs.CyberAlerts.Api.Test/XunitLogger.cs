#nullable enable
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using Xunit;

namespace Uk.Nhs.CyberAlerts.Api.Test;

/// <summary>
/// Logger that writes to xUnit test output.
/// </summary>
/// <param name="output">The xUnit output helper to write log messages to.</param>
/// <param name="categoryName">The logger category name.</param>
/// <param name="minLevel">The minimum log level that will be written.</param>
public class XunitLogger(ITestOutputHelper output, string categoryName, LogLevel minLevel = LogLevel.Debug) : ILogger
{
	private readonly ITestOutputHelper _output = output;
	private readonly string _categoryName = categoryName;
	private readonly LogLevel _minLevel = minLevel;

	/// <summary>
	/// Begins a logical operation scope.
	/// </summary>
	/// <typeparam name="TState">The type of the scope state.</typeparam>
	/// <param name="state">The state to associate with the scope.</param>
	/// <returns>A disposable scope handle, or <see langword="null"/> when scopes are not used.</returns>
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

	/// <summary>
	/// Determines whether the specified log level is enabled.
	/// </summary>
	/// <param name="logLevel">The log level to evaluate.</param>
	/// <returns><see langword="true"/> when the level is enabled; otherwise, <see langword="false"/>.</returns>
	public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLevel;

	/// <summary>
	/// Writes a log entry to the xUnit output stream.
	/// </summary>
	/// <typeparam name="TState">The type of the log state.</typeparam>
	/// <param name="logLevel">The severity of the log entry.</param>
	/// <param name="eventId">The event identifier.</param>
	/// <param name="state">The state to log.</param>
	/// <param name="exception">The exception associated with the log entry, if any.</param>
	/// <param name="formatter">The formatter used to create the log message.</param>
	public void Log<TState>(
		LogLevel logLevel,
		EventId eventId,
		TState state,
		Exception? exception,
		Func<TState, Exception?, string> formatter)
	{
		if (!IsEnabled(logLevel))
		{
			return;
		}

		var message = formatter(state, exception);
		var timestamp = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
		var logLevelString = logLevel switch
		{
			LogLevel.Trace => "TRACE",
			LogLevel.Debug => "DEBUG",
			LogLevel.Information => "INFO ",
			LogLevel.Warning => "WARN ",
			LogLevel.Error => "ERROR",
			LogLevel.Critical => "CRIT ",
			_ => "NONE "
		};

		var logOutput = $"[{timestamp}] [{logLevelString}] [{_categoryName}] {message}";

		if (eventId.Id != 0)
		{
			logOutput = $"[{timestamp}] [{logLevelString}] [{_categoryName}] [EventId:{eventId.Id}] {message}";
		}

		try
		{
			_output.WriteLine(logOutput);

			if (exception != null)
			{
				_output.WriteLine($"Exception: {exception}");
			}
		}
		catch
		{
			// If test output is not available, ignore
		}
	}
}

/// <summary>
/// Logger provider for xUnit test output.
/// </summary>
/// <param name="output">The xUnit output helper to write log messages to.</param>
/// <param name="minLevel">The minimum log level that will be written.</param>
public class XunitLoggerProvider(ITestOutputHelper output, LogLevel minLevel = LogLevel.Debug) : ILoggerProvider
{
	private readonly ITestOutputHelper _output = output;
	private readonly LogLevel _minLevel = minLevel;

	/// <summary>
	/// Creates a logger for the supplied category.
	/// </summary>
	/// <param name="categoryName">The category name for the logger.</param>
	/// <returns>A logger that writes to xUnit output.</returns>
	public ILogger CreateLogger(string categoryName)
	{
		return new XunitLogger(_output, categoryName, _minLevel);
	}

	/// <summary>
	/// Releases provider resources.
	/// </summary>
	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
