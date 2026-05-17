using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Smart_Student_System {
    public class SortAlgorithms {
        // Bubble Sort - O(n²)
        public static List<Student> BubbleSort(List<Student> students) {
            List<Student> sortedList = new List<Student>(students);
            int n = sortedList.Count;

            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (sortedList[j].Marks < sortedList[j + 1].Marks) // Descending order
                    {
                        // Swap
                        Student temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }
            return sortedList;
        }

        // Quick Sort - O(n log n)
        public static List<Student> QuickSort(List<Student> students) {
            List<Student> sortedList = new List<Student>(students);
            QuickSortHelper(sortedList, 0, sortedList.Count - 1);
            return sortedList;
        }

        private static void QuickSortHelper(List<Student> students, int low, int high) {
            if (low < high) {
                int pi = Partition(students, low, high);
                QuickSortHelper(students, low, pi - 1);
                QuickSortHelper(students, pi + 1, high);
            }
        }

        private static int Partition(List<Student> students, int low, int high) {
            int pivot = students[high].Marks;
            int i = (low - 1);

            for (int j = low; j < high; j++) {
                if (students[j].Marks >= pivot) // Descending order
                {
                    i++;
                    Student temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                }
            }

            Student temp1 = students[i + 1];
            students[i + 1] = students[high];
            students[high] = temp1;

            return i + 1;
        }

        // Insertion Sort - O(n²) but good for small datasets
        public static List<Student> InsertionSort(List<Student> students) {
            List<Student> sortedList = new List<Student>(students);
            int n = sortedList.Count;

            for (int i = 1; i < n; i++) {
                Student key = sortedList[i];
                int j = i - 1;

                while (j >= 0 && sortedList[j].Marks < key.Marks) // Descending order
                {
                    sortedList[j + 1] = sortedList[j];
                    j--;
                }
                sortedList[j + 1] = key;
            }
            return sortedList;
        }
    }
}