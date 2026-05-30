using Xunit;
using UserManagementSystem.Core.Services;
using UserManagementSystem.Core.Helpers;

namespace UserManagementSystem.Tests;

public class UserAuthTests {
    [Fact]
    public void Register_NewUser_ShouldReturnTrue() {
        var auth = new AuthService();
        var result = auth.Register("Raj", "pass123");
        Assert.True(result);
    }

    [Fact]
    public void Authenticate_ValidUser_ShouldReturnTrue() {
        var auth = new AuthService();
        auth.Register("Raj", "pass123");
        var result = auth.Authenticate("Raj", "pass123");
        Assert.True(result);
    }

    [Fact]
    public void Authenticate_WrongPassword_ShouldReturnFalse() {
        var auth = new AuthService();
        auth.Register("Raj", "pass123");
        var result = auth.Authenticate("Raj", "wrong");
        Assert.False(result);
    }

    [Fact]
    public void PasswordHash_ShouldBeSameForSameInput() {
        var hash1 = PasswordHelper.HashPassword("same");
        var hash2 = PasswordHelper.HashPassword("same");
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void Encryption_Decryption_ShouldReturnOriginal() {
        var original = "MySecretData";
        var encrypted = EncryptionHelper.Encrypt(original);
        var decrypted = EncryptionHelper.Decrypt(encrypted);
        Assert.Equal(original, decrypted);
    }

    [Fact]
    public void Register_DuplicateUser_ShouldReturnFalse() {
        var auth = new AuthService();
        auth.Register("Raj", "pass123");
        var result = auth.Register("Raj", "pass456");
        Assert.False(result);
    }
}