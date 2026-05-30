using _1_SOLID_ReportingSystem.Models;

namespace _1_SOLID_ReportingSystem.Models {
    public class SalesReport : Report {
        public decimal TotalSales { get; set; }
        public string Region { get; set; }

        public SalesReport(string title, string author, decimal totalSales, string region)
            : base(title, author) {
            TotalSales = totalSales;
            Region = region;
        }

        public override string GetContent() {
            return $"Sales Report for {Region}\nTotal Sales: ₹{TotalSales}";
        }

        public override string GetMetadata() {
            return base.GetMetadata() + $", Region: {Region}";
        }
    }
}