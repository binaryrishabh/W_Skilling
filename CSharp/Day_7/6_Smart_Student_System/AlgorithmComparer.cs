using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace _6_Smart_Student_System {
    public class AlgorithmComparer {
        public static void DisplayComparison() {
            Console.WriteLine("\n===== Algorithm Comparison =====");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-25}",
                "Algorithm", "Time Complexity", "Space", "Best Use Case");
            Console.WriteLine(new string('-', 75));

            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-25}",
                "Linear Search", "O(n)", "O(1)", "Unsorted/Small Data");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-25}",
                "Binary Search", "O(log n)", "O(1)", "Sorted Arrays");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-25}",
                "Bubble Sort", "O(n²)", "O(1)", "Small Data/Educational");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-25}",
                "Insertion Sort", "O(n²)", "O(1)", "Small Datasets (<50)");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-25}",
                "Quick Sort", "O(n log n)", "O(log n)", "Large Datasets");

            Console.WriteLine("\nRecommendations:");
            Console.WriteLine("✓ Best for small datasets (<50): Insertion Sort");
            Console.WriteLine("✓ Best for large datasets: Quick Sort");
            Console.WriteLine("✓ Use Binary Search only on sorted data");
            Console.WriteLine("✓ Use Linear Search for unsorted data");
        }
    }
}