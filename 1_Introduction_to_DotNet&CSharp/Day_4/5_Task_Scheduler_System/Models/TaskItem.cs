namespace _5_Task_Scheduler_System.Models {
    public class TaskItem {
        public int Priority { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskItem(int priority, string taskName) {
            Priority = priority;
            TaskName = taskName;
            CreatedAt = DateTime.Now;
        }

        public override string ToString() {
            return $"[Priority: {Priority}] {TaskName} (Created: {CreatedAt:T})";
        }

        public override bool Equals(object? obj) {
            if (obj is TaskItem task) {
                return TaskName == task.TaskName;
            }
            return false;
        }

        public override int GetHashCode() {
            return TaskName?.GetHashCode() ?? 0;
        }
    }
}