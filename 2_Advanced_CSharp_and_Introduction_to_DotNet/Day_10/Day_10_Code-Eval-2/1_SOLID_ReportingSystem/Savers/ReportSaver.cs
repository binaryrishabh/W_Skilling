using _1_SOLID_ReportingSystem.Interfaces;

namespace _1_SOLID_ReportingSystem.Savers {
    public class ReportSaver : IReportSaver {
        public void Save(string content, string filePath) {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"Saved to: {filePath}");
        }
    }
}