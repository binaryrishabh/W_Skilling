using _6_ReportingService.Models;
using _6_ReportingService.Services;
using _6_ReportingService.Utilities;

namespace _6_ReportingService;

class Program {
    static async Task Main(string[] args) {
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine("   REPORTING SERVICE - Threading Assignment");
        Console.WriteLine("=".PadRight(60, '='));

        var generator = new ReportGenerator();
        var timeTracker = new TimeTracker();

        // Define reports to generate
        var reports = new[]
        {
            "Sales Report",
            "Inventory Report",
            "User Report",
            "Payment Report",
            "Audit Report"
        };

        // ================================================
        // TAKE INPUT: Indian Names for each report
        // ================================================
        Console.WriteLine("\n📝 Enter Indian names for each report (First Name only):");
        Console.WriteLine("-".PadRight(50, '-'));

        var userNames = new List<string>();

        for (int i = 0; i < reports.Length; i++) {
            Console.Write($"   Name for {reports[i]}: ");
            string? name = Console.ReadLine();

            // Validate input (if empty, use default name)
            if (string.IsNullOrWhiteSpace(name)) {
                name = "Unknown";
                Console.WriteLine($"      ⚠️  Using default name: Unknown");
            }
            else {
                // Capitalize first letter
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            }

            userNames.Add(name);
        }

        // ================================================
        // PART 1: SEQUENTIAL EXECUTION (No Threading)
        // ================================================
        Console.WriteLine("\n\n📋 PART 1: SEQUENTIAL EXECUTION (One by One)");
        Console.WriteLine("-".PadRight(50, '-'));

        var sequentialReports = new List<Report>();
        timeTracker.Start();

        for (int i = 0; i < reports.Length; i++) {
            var report = generator.GenerateReport(reports[i], userNames[i]);
            sequentialReports.Add(report);
        }

        timeTracker.Stop();
        double sequentialTime = timeTracker.GetElapsedSeconds();
        timeTracker.DisplayTime("Sequential Execution");

        // Display results
        Console.WriteLine("\n📊 Reports Generated (Sequential):");
        foreach (var report in sequentialReports) {
            Console.WriteLine($"   {report}");
        }

        // ================================================
        // PART 2: PARALLEL EXECUTION (With Threading)
        // ================================================
        Console.WriteLine("\n\n📋 PART 2: PARALLEL EXECUTION (All at Once using Tasks)");
        Console.WriteLine("-".PadRight(50, '-'));

        var parallelReports = new List<Report>();
        var tasks = new List<Task<Report>>();

        timeTracker.Start();

        // Launch all reports simultaneously with user-provided names
        for (int i = 0; i < reports.Length; i++) {
            int index = i; // Capture for lambda
            var task = Task.Run(() => generator.GenerateReport(reports[index], userNames[index]));
            tasks.Add(task);
        }

        // Wait for all to complete
        var results = await Task.WhenAll(tasks);
        parallelReports.AddRange(results);

        timeTracker.Stop();
        double parallelTime = timeTracker.GetElapsedSeconds();
        timeTracker.DisplayTime("Parallel Execution");

        // Display results
        Console.WriteLine("\n📊 Reports Generated (Parallel):");
        foreach (var report in parallelReports) {
            Console.WriteLine($"   {report}");
        }

        // ================================================
        // PART 3: COMPARISON & SUMMARY
        // ================================================
        Console.WriteLine("\n\n" + "=".PadRight(60, '='));
        Console.WriteLine("   PERFORMANCE COMPARISON");
        Console.WriteLine("=".PadRight(60, '='));

        double speedup = sequentialTime / parallelTime;
        double timeSaved = sequentialTime - parallelTime;

        Console.WriteLine($"\n📈 Sequential Time:  {sequentialTime:F2} seconds");
        Console.WriteLine($"⚡ Parallel Time:    {parallelTime:F2} seconds");
        Console.WriteLine($"🚀 Speedup Factor:   {speedup:F2}x faster");
        Console.WriteLine($"⏱️  Time Saved:       {timeSaved:F2} seconds");

        if (speedup > 1) {
            Console.WriteLine($"\n✅ SUCCESS: Using threading made the process {speedup:F1}x faster!");
        }

        Console.WriteLine("\n" + "=".PadRight(60, '='));

        // Display who generated which report
        Console.WriteLine("\n📋 SUMMARY - Report Assignments:");
        Console.WriteLine("-".PadRight(50, '-'));
        for (int i = 0; i < reports.Length; i++) {
            Console.WriteLine($"   {reports[i]} → Generated by: {userNames[i]}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}