using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Linq;
using WindowsPerformanceMcpServer.Tools;

namespace SampleMcpServer.Tools;

public class WindowsPerformanceTools(
    IPerformanceCounterService performanceCounterService)
{
    /// <summary>
    /// Retrieves a table with cpu usage statistics for the current machine.
    /// </summary>
    /// <returns></returns>
    [McpServerTool()]
    [Description("Retrieves a table with cpu usage statistics for the current machine.")]
    public string GetCpuUsage()
    {
        var values = performanceCounterService.CpuValues
            .TakeLast(20)
            .Select(t => $"{t.Item1:yyyy-MM-dd HH:dd:ss} - {(int)t.Item2}%");

        return $@"These are the last 20 CPU measurements:
- {string.Join("\n- ", values)}";
    }
}