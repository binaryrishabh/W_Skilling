using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaPlatform {
    class Program {
        // Collections as per requirements
        static List<string> posts = new List<string>();
        static Dictionary<string, int> likesPerPost = new Dictionary<string, int>();
        static HashSet<int> uniqueUserIds = new HashSet<int>();
        static Stack<string> recentActions = new Stack<string>();  // For undo functionality
        static Queue<string> notifications = new Queue<string>();   // For processing notifications

        static void Main(string[] args) {
            Console.WriteLine("=== Social Media Platform (User Engagement System) ===\n");

            bool running = true;
            while (running) {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Add a new post");
                Console.WriteLine("2. Like a post");
                Console.WriteLine("3. Register a user");
                Console.WriteLine("4. Display all posts with likes");
                Console.WriteLine("5. Display unique users");
                Console.WriteLine("6. Undo last action");
                Console.WriteLine("7. Process notifications");
                Console.WriteLine("8. Add notification to queue");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        AddPost();
                        break;
                    case "2":
                        LikePost();
                        break;
                    case "3":
                        RegisterUser();
                        break;
                    case "4":
                        DisplayPosts();
                        break;
                    case "5":
                        DisplayUniqueUsers();
                        break;
                    case "6":
                        UndoLastAction();
                        break;
                    case "7":
                        ProcessNotifications();
                        break;
                    case "8":
                        AddNotification();
                        break;
                    case "9":
                        running = false;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // 1. Add a new post (using List<string>)
        static void AddPost() {
            Console.Write("Enter post content: ");
            string post = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(post)) {
                posts.Add(post);
                // Initialize likes for this post to 0
                likesPerPost[post] = 0;

                // Track action for undo
                recentActions.Push($"ADD_POST|{post}");

                Console.WriteLine($"Post added successfully! Total posts: {posts.Count}");
            }
            else {
                Console.WriteLine("Post cannot be empty.");
            }
        }

        // 2. Like a post (using Dictionary<string, int>)
        static void LikePost() {
            if (posts.Count == 0) {
                Console.WriteLine("No posts available to like.");
                return;
            }

            Console.WriteLine("\nAvailable posts:");
            for (int i = 0; i < posts.Count; i++) {
                Console.WriteLine($"{i + 1}. {posts[i]} (Likes: {likesPerPost[posts[i]]})");
            }

            Console.Write("Select post number to like: ");
            if (int.TryParse(Console.ReadLine(), out int postIndex) && postIndex >= 1 && postIndex <= posts.Count) {
                string selectedPost = posts[postIndex - 1];
                likesPerPost[selectedPost]++;

                // Track action for undo
                recentActions.Push($"LIKE_POST|{selectedPost}");

                Console.WriteLine($"You liked: \"{selectedPost}\" (Total likes: {likesPerPost[selectedPost]})");
            }
            else {
                Console.WriteLine("Invalid post selection.");
            }
        }

        // 3. Register a user (using HashSet<int> for unique user IDs)
        static void RegisterUser() {
            Console.Write("Enter user ID (number): ");
            if (int.TryParse(Console.ReadLine(), out int userId)) {
                if (uniqueUserIds.Add(userId)) {
                    recentActions.Push($"REGISTER_USER|{userId}");
                    Console.WriteLine($"User {userId} registered successfully!");
                }
                else {
                    Console.WriteLine($"User {userId} already exists. Unique users: {uniqueUserIds.Count}");
                }
            }
            else {
                Console.WriteLine("Invalid user ID. Please enter a number.");
            }
        }

        // 4. Display all posts with likes
        static void DisplayPosts() {
            if (posts.Count == 0) {
                Console.WriteLine("No posts available.");
                return;
            }

            Console.WriteLine("\n=== All Posts ===");
            for (int i = 0; i < posts.Count; i++) {
                Console.WriteLine($"{i + 1}. {posts[i]}");
                Console.WriteLine($"   ❤️ Likes: {likesPerPost[posts[i]]}");
                Console.WriteLine("   ---");
            }
        }

        // 5. Display unique users (HashSet<int>)
        static void DisplayUniqueUsers() {
            if (uniqueUserIds.Count == 0) {
                Console.WriteLine("No users registered yet.");
                return;
            }

            Console.WriteLine($"\n=== Unique Users (Total: {uniqueUserIds.Count}) ===");
            foreach (int userId in uniqueUserIds.OrderBy(id => id)) {
                Console.WriteLine($"👤 User ID: {userId}");
            }
        }

        // 6. Undo last action (using Stack<string> LIFO)
        static void UndoLastAction() {
            if (recentActions.Count == 0) {
                Console.WriteLine("No actions to undo.");
                return;
            }

            string lastAction = recentActions.Pop();
            string[] parts = lastAction.Split('|');
            string actionType = parts[0];
            string value = parts[1];

            switch (actionType) {
                case "ADD_POST":
                    // Remove the last added post
                    if (posts.Contains(value)) {
                        posts.Remove(value);
                        likesPerPost.Remove(value);
                        Console.WriteLine($"Undo: Post \"{value}\" has been removed.");
                    }
                    break;

                case "LIKE_POST":
                    if (likesPerPost.ContainsKey(value) && likesPerPost[value] > 0) {
                        likesPerPost[value]--;
                        Console.WriteLine($"Undo: Like removed from post \"{value}\". Now has {likesPerPost[value]} likes.");
                    }
                    else {
                        Console.WriteLine($"Cannot undo like: Post \"{value}\" no longer exists or has no likes.");
                    }
                    break;

                case "REGISTER_USER":
                    // Remove user ID
                    int userId = int.Parse(value);
                    if (uniqueUserIds.Contains(userId)) {
                        uniqueUserIds.Remove(userId);
                        Console.WriteLine($"Undo: User {userId} has been unregistered.");
                    }
                    break;

                default:
                    Console.WriteLine($"Unknown action type: {actionType}");
                    break;
            }
        }

        // 7. Process notifications sequentially (using Queue<string> FIFO)
        static void ProcessNotifications() {
            if (notifications.Count == 0) {
                Console.WriteLine("No notifications to process.");
                return;
            }

            Console.WriteLine("\n=== Processing Notifications (FIFO) ===");
            int processedCount = 0;
            while (notifications.Count > 0) {
                string notification = notifications.Dequeue();
                Console.WriteLine($"📢 Processing: {notification}");
                processedCount++;
            }
            Console.WriteLine($"✅ Processed {processedCount} notification(s).");
        }

        // 8. Add notification to queue
        static void AddNotification() {
            Console.Write("Enter notification message: ");
            string message = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(message)) {
                notifications.Enqueue(message);
                Console.WriteLine($"Notification added to queue. Queue size: {notifications.Count}");
            }
            else {
                Console.WriteLine("Notification cannot be empty.");
            }
        }
    }
}