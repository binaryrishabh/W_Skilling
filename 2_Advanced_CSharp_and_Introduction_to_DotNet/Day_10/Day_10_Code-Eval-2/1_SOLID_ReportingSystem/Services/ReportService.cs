using _1_SOLID_ReportingSystem.Interfaces;

namespace _1_SOLID_ReportingSystem.Services {
    public class ReportService {
        private readonly IReportGenerator _generator;
        private readonly IReportSaver _saver;
        private readonly IReportFormatter _formatter;

        public ReportService(IReportGenerator generator, IReportSaver saver, IReportFormatter formatter) {
            _generator = generator;
            _saver = saver;
            _formatter = formatter;
        }

        public void ProcessReport(string data, string filePath) {
            string rawReport = _generator.Generate(data);
            string formattedReport = _formatter.Format(rawReport);
            _saver.Save(formattedReport, filePath);
        }
    }
}