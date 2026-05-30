namespace _1_SOLID_ReportingSystem.Models {
    public abstract class Report {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }

        protected Report(string title, string author) {
            Title = title;
            Author = author;
            CreatedDate = DateTime.Now;
        }

        public abstract string GetContent();

        public virtual string GetMetadata() {
            return $"Title: {Title}, Author: {Author}, Date: {CreatedDate}";
        }
    }
}