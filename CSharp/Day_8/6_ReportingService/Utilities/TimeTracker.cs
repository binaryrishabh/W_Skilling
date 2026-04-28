using System.Diagnostics;

namespace _6_ReportingService.Utilities;

public class TimeTracker {
    private Stopwatch _stopwatch;

    public TimeTracker() {
        _stopwatch = new Stopwatch();
    }

    public void Start() {
        _stopwatch.Restart();
    }

    public void Stop() {
        _stopwatch.Stop();
    }

    public double GetElapsedSeconds() {
        return _stopwatch.Elapsed.TotalSeconds;
    }

    public void DisplayTime(string operationName) {
        Console.WriteLine($"\n⏱️  {operationName} took: {GetElapsedSeconds():F2} seconds");
    }
}