namespace _6_ReportingService.Models;

public class Report {
    public string Name { get; set; }
    public string GeneratedBy { get; set; }
    public int RecordCount { get; set; }
    public string Status { get; set; }

    public Report(string name, string generatedBy) {
        Name = name;
        GeneratedBy = generatedBy;
        Status = "Pending";
    }

    public override string ToString() {
        return $"{Name} | By: {GeneratedBy} | Records: {RecordCount} | Status: {Status}";
    }
}