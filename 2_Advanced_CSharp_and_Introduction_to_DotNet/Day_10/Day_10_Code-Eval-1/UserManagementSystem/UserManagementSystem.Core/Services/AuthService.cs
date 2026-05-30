using System.Collections.Generic;
using UserManagementSystem.Core.Helpers;
using UserManagementSystem.Core.Models;
using Serilog;

namespace UserManagementSystem.Core.Services;

public class AuthService {
    private readonly Dictionary<string, User> _users = new();

    public bool Register(string username, string password) {
        try {
            if (_users.ContainsKey(username))
                return false;

            var hashed = PasswordHelper.HashPassword(password);
            _users[username] = new User { Username = username, HashedPassword = hashed };

            Log.Information("User registered: {Username}", username);
            return true;
        }
        catch (System.Exception ex) {
            Log.Error(ex, "Registration failed for {Username}", username);
            return false;
        }
    }

    public bool Authenticate(string username, string password) {
        try {
            if (!_users.ContainsKey(username))
                return false;

            var user = _users[username];
            return PasswordHelper.VerifyPassword(password, user.HashedPassword);
        }
        catch (System.Exception ex) {
            Log.Error(ex, "Authentication failed for {Username}", username);
            return false;
        }
    }
}