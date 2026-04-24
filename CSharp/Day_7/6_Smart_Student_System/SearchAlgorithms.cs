using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Smart_Student_System {
    public class SearchAlgorithms {
        // Linear Search
        public static (int index, Student student) LinearSearch(List<Student> students, int id) {
            for (int i = 0; i < students.Count; i++) {
                if (students[i].Id == id) {
                    return (i, students[i]);
                }
            }
            return (-1, null);
        }

        // Binary Search (requires sorted array by ID)
        public static (int index, Student student) BinarySearch(List<Student> students, int id) {
            // First sort by ID
            List<Student> sortedList = new List<Student>(students);
            sortedList.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));

            int left = 0;
            int right = sortedList.Count - 1;

            while (left <= right) {
                int mid = left + (right - left) / 2;

                if (sortedList[mid].Id == id) {
                    return (mid, sortedList[mid]);
                }

                if (sortedList[mid].Id < id) {
                    left = mid + 1;
                }
                else {
                    right = mid - 1;
                }
            }

            return (-1, null);
        }
    }
}