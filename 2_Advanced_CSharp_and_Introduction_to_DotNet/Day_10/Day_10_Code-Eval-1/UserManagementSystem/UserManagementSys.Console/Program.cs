using UserManagementSystem.Core.Services;
using Serilog;

namespace UserManagementSystem.Console;

class Program {
    static void Main() {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var auth = new AuthService();
        var data = new UserDataService();

        System.Console.WriteLine("=== User Management System ===");
        System.Console.WriteLine("1. Register");
        System.Console.WriteLine("2. Login");
        System.Console.Write("Choose (1 or 2): ");
        var choice = System.Console.ReadLine();

        if (choice == "1") {
            System.Console.Write("Username (Indian name): ");
            var user = System.Console.ReadLine();
            System.Console.Write("Password: ");
            var pwd = System.Console.ReadLine();

            if (auth.Register(user, pwd)) {
                System.Console.WriteLine("Registration successful!");
                System.Console.Write("Enter secret data to encrypt: ");
                var secret = System.Console.ReadLine();
                data.SaveSensitiveData(user, secret);
                System.Console.WriteLine("Secret data saved encrypted.");
            }
            else {
                System.Console.WriteLine("Registration failed. Username may exist.");
            }
        }
        else if (choice == "2") {
            System.Console.Write("Username: ");
            var user = System.Console.ReadLine();
            System.Console.Write("Password: ");
            var pwd = System.Console.ReadLine();

            if (auth.Authenticate(user, pwd)) {
                System.Console.WriteLine("Login successful!");
                var secret = data.GetSensitiveData(user);
                if (secret != null)
                    System.Console.WriteLine($"Your decrypted data: {secret}");
                else
                    System.Console.WriteLine("No saved data found.");
            }
            else {
                System.Console.WriteLine("Login failed. Invalid credentials.");
            }
        }

        System.Console.WriteLine("Press any key to exit...");
        System.Console.ReadKey();
    }
}