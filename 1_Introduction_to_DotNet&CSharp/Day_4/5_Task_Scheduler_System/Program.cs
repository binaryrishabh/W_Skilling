using System;
using _5_Task_Scheduler_System.Services;

namespace _5_Task_Scheduler_System {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("   TASK SCHEDULER SYSTEM");
            Console.WriteLine("═══════════════════════════════════════\n");

            ScheduleManager scheduler = new ScheduleManager();

            bool running = true;
            while (running) {
                DisplayMenu();
                string? choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        AddNewTask(scheduler);
                        break;
                    case "2":
                        scheduler.ExecuteNextTask();
                        break;
                    case "3":
                        scheduler.UndoLastTask();
                        break;
                    case "4":
                        scheduler.ExecuteByPriority();
                        break;
                    case "5":
                        scheduler.DisplayAllTasks();
                        break;
                    case "6":
                        scheduler.DisplayExecutionQueue();
                        break;
                    case "7":
                        scheduler.DisplayUndoStack();
                        break;
                    case "8":
                        scheduler.DisplayPriorityTasks();
                        break;
                    case "9":
                        scheduler.DisplayStatistics();
                        break;
                    case "10":
                        Console.WriteLine("\n👋 Exiting Task Scheduler System...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\n❌ Invalid option! Please try again.");
                        break;
                }

                if (running) {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void DisplayMenu() {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("            MAIN MENU");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. Execute Next Task (Queue Order)");
            Console.WriteLine("3. Undo Last Executed Task");
            Console.WriteLine("4. Execute Highest Priority Task");
            Console.WriteLine("5. Display All Tasks");
            Console.WriteLine("6. Display Execution Queue");
            Console.WriteLine("7. Display Undo Stack");
            Console.WriteLine("8. Display Priority Tasks");
            Console.WriteLine("9. Display Statistics");
            Console.WriteLine("10. Exit");
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("\nEnter your choice: ");
        }

        static void AddNewTask(ScheduleManager scheduler) {
            Console.WriteLine("\n━━━ Add New Task ━━━");

            Console.Write("Enter task name: ");
            string? taskName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(taskName)) {
                Console.WriteLine("❌ Task name cannot be empty!");
                return;
            }

            Console.Write("Enter priority (1 = highest, 5 = lowest): ");
            if (!int.TryParse(Console.ReadLine(), out int priority)) {
                Console.WriteLine("❌ Invalid priority! Using default (5).");
                priority = 5;
            }

            // Validate priority range
            if (priority < 1 || priority > 10) {
                Console.WriteLine("❌ Priority must be between 1 and 10! Using default (5).");
                priority = 5;
            }

            scheduler.AddTask(taskName, priority);
        }
    }
}