using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System;
using System.ComponentModel;
using System.Net.Http;

namespace SampleMcpServer.Tools;

public class WindowsPerformanceTools(
    IAppSettings config,
    HttpClient httpClient,
    ILoggerFactory loggerFactory)
{
    private readonly ILogger<WindowsPerformanceTools> _logger = loggerFactory.CreateLogger<WindowsPerformanceTools>();

    /// <summary>
    /// Retrieves a table with performance statistics for the current machine.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    [McpServerTool()]
    [Description("Retrieves a table with performance statistics for the current machine.")]
    public string CurrentPerformance()
    {
        _logger
            .LogInformation("CurrentPerformance");

        return "Empty list";
    }
}