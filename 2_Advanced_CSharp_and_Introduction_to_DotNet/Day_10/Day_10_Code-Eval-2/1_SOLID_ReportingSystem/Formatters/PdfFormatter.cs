using _1_SOLID_ReportingSystem.Interfaces;

namespace _1_SOLID_ReportingSystem.Formatters {
    public class PdfFormatter : IReportFormatter {
        public string Format(string content) {
            return $"[PDF Format]\n{content}\n[End PDF]";
        }
    }
}