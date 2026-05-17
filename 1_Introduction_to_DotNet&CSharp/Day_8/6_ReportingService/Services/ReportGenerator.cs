using System.Diagnostics;
using _6_ReportingService.Models;

namespace _6_ReportingService.Services;

public class ReportGenerator {
    private static readonly Random _random = new Random();

    // Method to generate a single report (simulates heavy work)
    public Report GenerateReport(string reportName, string generatedBy) {
        Console.WriteLine($"  [START] Generating {reportName} for {generatedBy}...");

        // Simulate time-consuming report generation (2-5 seconds)
        int generationTime = _random.Next(2000, 5000);
        Thread.Sleep(generationTime);

        var report = new Report(reportName, generatedBy);
        report.RecordCount = _random.Next(100, 1000);
        report.Status = "Completed";

        Console.WriteLine($"  [DONE]  {reportName} for {generatedBy} completed in {generationTime}ms");
        return report;
    }
}