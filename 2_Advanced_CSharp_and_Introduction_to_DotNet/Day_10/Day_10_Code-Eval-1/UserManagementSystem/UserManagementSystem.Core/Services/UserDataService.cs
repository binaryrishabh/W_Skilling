using System.Collections.Generic;
using UserManagementSystem.Core.Helpers;
using Serilog;

namespace UserManagementSystem.Core.Services;

public class UserDataService {
    private readonly Dictionary<string, string> _encryptedData = new();

    public void SaveSensitiveData(string username, string data) {
        var encrypted = EncryptionHelper.Encrypt(data);
        _encryptedData[username] = encrypted;
        Log.Information("Data saved for {Username}", username);
    }

    public string GetSensitiveData(string username) {
        if (!_encryptedData.ContainsKey(username))
            return null;

        var decrypted = EncryptionHelper.Decrypt(_encryptedData[username]);
        Log.Information("Data retrieved for {Username}", username);
        return decrypted;
    }
}