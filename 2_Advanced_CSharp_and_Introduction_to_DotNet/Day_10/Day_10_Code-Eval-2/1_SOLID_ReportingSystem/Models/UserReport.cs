using _1_SOLID_ReportingSystem.Models;

namespace _1_SOLID_ReportingSystem.Models {
    public class UserReport : Report {
        public int UserCount { get; set; }
        public string UserType { get; set; }

        public UserReport(string title, string author, int userCount, string userType)
            : base(title, author) {
            UserCount = userCount;
            UserType = userType;
        }

        public override string GetContent() {
            return $"User Report - {UserType}\nTotal Users: {UserCount}";
        }
    }
}