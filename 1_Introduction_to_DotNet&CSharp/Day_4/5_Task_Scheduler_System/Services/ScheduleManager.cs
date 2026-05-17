using System;
using System.Collections.Generic;
using System.Linq;
using _5_Task_Scheduler_System.Models;

namespace _5_Task_Scheduler_System.Services {
    public class ScheduleManager {
        // Queue for task execution order (FIFO)
        private Queue<string> _executionQueue;

        // Stack for undoing last executed task (LIFO)
        private Stack<string> _undoStack;

        // List for all tasks
        private List<string> _allTasks;

        // SortedDictionary for priority-based tasks (sorted by priority)
        private SortedDictionary<int, string> _priorityTasks;

        // HashSet to ensure no duplicate tasks
        private HashSet<string> _uniqueTasks;

        public ScheduleManager() {
            _executionQueue = new Queue<string>();
            _undoStack = new Stack<string>();
            _allTasks = new List<string>();
            _priorityTasks = new SortedDictionary<int, string>();
            _uniqueTasks = new HashSet<string>();
        }

        // Add a new task (prevents duplicates)
        public bool AddTask(string taskName, int priority) {
            // Check for duplicate using HashSet
            if (_uniqueTasks.Contains(taskName)) {
                Console.WriteLine($"❌ Error: Task '{taskName}' already exists!");
                return false;
            }

            // Add to HashSet for uniqueness check
            _uniqueTasks.Add(taskName);

            // Add to List for all tasks
            _allTasks.Add(taskName);

            // Add to Queue for execution order
            _executionQueue.Enqueue(taskName);

            // Add to SortedDictionary for priority-based scheduling
            // Note: If priority already exists, we'll append with a suffix
            string existingTask;
            if (_priorityTasks.TryGetValue(priority, out existingTask)) {
                // Handle duplicate priority by combining tasks
                _priorityTasks[priority] = existingTask + " | " + taskName;
            }
            else {
                _priorityTasks.Add(priority, taskName);
            }

            Console.WriteLine($"✅ Task '{taskName}' added with priority {priority}");
            return true;
        }

        // Execute next task from queue
        public void ExecuteNextTask() {
            if (_executionQueue.Count == 0) {
                Console.WriteLine("⚠️ No tasks in queue to execute!");
                return;
            }

            string task = _executionQueue.Dequeue();
            Console.WriteLine($"▶️ Executing task: {task}");

            // Push to undo stack
            _undoStack.Push(task);
        }

        // Undo last executed task
        public void UndoLastTask() {
            if (_undoStack.Count == 0) {
                Console.WriteLine("⚠️ No tasks to undo!");
                return;
            }

            string undoneTask = _undoStack.Pop();
            Console.WriteLine($"↩️ Undid last executed task: {undoneTask}");

            // Optional: Re-add to execution queue
            _executionQueue.Enqueue(undoneTask);
            Console.WriteLine($"   (Task '{undoneTask}' re-added to execution queue)");
        }

        // Execute task by priority (highest priority = smallest number)
        public void ExecuteByPriority() {
            if (_priorityTasks.Count == 0) {
                Console.WriteLine("⚠️ No priority tasks available!");
                return;
            }

            Console.WriteLine("\n📊 Priority tasks available:");
            foreach (var priorityTask in _priorityTasks) {
                Console.WriteLine($"   Priority {priorityTask.Key}: {priorityTask.Value}");
            }

            // Get highest priority (first element in SortedDictionary)
            var highestPriority = _priorityTasks.First();
            Console.WriteLine($"\n🎯 Executing highest priority task:");
            Console.WriteLine($"   Priority {highestPriority.Key}: {highestPriority.Value}");

            // Remove after execution
            _priorityTasks.Remove(highestPriority.Key);
        }

        // Display all tasks
        public void DisplayAllTasks() {
            Console.WriteLine("\n📋 All Tasks:");
            if (_allTasks.Count == 0) {
                Console.WriteLine("   No tasks available.");
                return;
            }

            foreach (var task in _allTasks) {
                Console.WriteLine($"   • {task}");
            }
        }

        // Display execution queue
        public void DisplayExecutionQueue() {
            Console.WriteLine("\n⏳ Execution Queue (FIFO):");
            if (_executionQueue.Count == 0) {
                Console.WriteLine("   Queue is empty.");
                return;
            }

            int position = 1;
            foreach (var task in _executionQueue) {
                Console.WriteLine($"   {position}. {task}");
                position++;
            }
        }

        // Display undo stack
        public void DisplayUndoStack() {
            Console.WriteLine("\n↩️ Undo Stack (LIFO - Most recent first):");
            if (_undoStack.Count == 0) {
                Console.WriteLine("   Stack is empty.");
                return;
            }

            int position = 1;
            foreach (var task in _undoStack) {
                Console.WriteLine($"   {position}. {task}");
                position++;
            }
        }

        // Display priority tasks
        public void DisplayPriorityTasks() {
            Console.WriteLine("\n⭐ Priority Tasks (Sorted by priority - 1 is highest):");
            if (_priorityTasks.Count == 0) {
                Console.WriteLine("   No priority tasks available.");
                return;
            }

            foreach (var priorityTask in _priorityTasks) {
                Console.WriteLine($"   Priority {priorityTask.Key}: {priorityTask.Value}");
            }
        }

        // Get statistics
        public void DisplayStatistics() {
            Console.WriteLine("\n📊 System Statistics:");
            Console.WriteLine($"   Total unique tasks: {_uniqueTasks.Count}");
            Console.WriteLine($"   Tasks in queue (waiting): {_executionQueue.Count}");
            Console.WriteLine($"   Tasks in undo stack (executed): {_undoStack.Count}");
            Console.WriteLine($"   Priority tasks available: {_priorityTasks.Count}");
        }
    }
}