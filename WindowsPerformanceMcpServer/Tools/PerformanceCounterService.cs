using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace WindowsPerformanceMcpServer.Tools;

public interface IPerformanceCounterService
{
    IEnumerable<Tuple<DateTime, float>> CpuValues { get; }
}

public class PerformanceCounterService
    : IPerformanceCounterService
{
    private readonly PerformanceCounter _cpuCounter = new()
    {
        CategoryName = "Processor",
        CounterName = "% Processor Time",
        InstanceName = "_Total"
    };

    private readonly Timer _updateTimer;

    private readonly List<Tuple<DateTime, float>> _cpuCountedValues = [];

    public PerformanceCounterService()
    {
        _updateTimer = new(OnUpdate, this, 0, 1000);
    }

    private static void OnUpdate(object? state)
    {
        if (state is PerformanceCounterService thiz)
        {
            thiz._cpuCountedValues.Add(Tuple.Create(DateTime.Now, thiz._cpuCounter.NextValue()));
        }
    }

    public IEnumerable<Tuple<DateTime, float>> CpuValues => _cpuCountedValues;
}
