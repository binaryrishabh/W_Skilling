using _1_SOLID_ReportingSystem.Formatters;
using _1_SOLID_ReportingSystem.Interfaces;
using _1_SOLID_ReportingSystem.Models;
using _1_SOLID_ReportingSystem.Savers;
using _1_SOLID_ReportingSystem.Services;

namespace _1_SOLID_ReportingSystem {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== SOLID Reporting System ===\n");

            // LSP Demo: Using base class reference for derived classes
            Console.WriteLine("--- LSP Demo: Reports ---");
            Report report1 = new SalesReport("Q1 Sales", "pr", 150000, "Mumbai");
            Report report2 = new UserReport("Active Users", "PR", 1250, "Premium");

            DisplayReport(report1);
            DisplayReport(report2);

            Console.WriteLine("\n--- Generate and Save Report ---");

            // Choose formatter
            Console.Write("Enter format (pdf/excel): ");
            string format = Console.ReadLine().ToLower();

            IReportFormatter formatter = format == "pdf" ? new PdfFormatter() : new ExcelFormatter();

            var generator = new ReportGenerator();
            var saver = new ReportSaver();
            var reportService = new ReportService(generator, saver, formatter);

            // Use SalesReport data
            string data = report1.GetContent();
            string filePath = $@"C:\Users\Rishabh\Documents\Wipro_Skilling\2_Advanced_CSharp_and_Introduction_to_DotNet\Day_10\Day_10_Code-Eval-2\1_SOLID_ReportingSystem\report_{DateTime.Now.Ticks}.txt";

            reportService.ProcessReport(data, filePath);
            Console.WriteLine($"\nReport saved: {filePath}");
            Console.ReadLine();
        }

        // LSP: Works with any derived Report type
        static void DisplayReport(Report report) {
            Console.WriteLine(report.GetMetadata());
            Console.WriteLine(report.GetContent());
            Console.WriteLine();
        }
    }
}