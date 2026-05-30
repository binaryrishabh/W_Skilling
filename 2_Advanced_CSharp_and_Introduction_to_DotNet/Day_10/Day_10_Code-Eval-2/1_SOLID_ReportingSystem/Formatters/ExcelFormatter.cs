using _1_SOLID_ReportingSystem.Interfaces;

namespace _1_SOLID_ReportingSystem.Formatters {
    public class ExcelFormatter : IReportFormatter {
        public string Format(string content) {
            return $"[EXCEL Format]\n{content}\n[End EXCEL]";
        }
    }
}