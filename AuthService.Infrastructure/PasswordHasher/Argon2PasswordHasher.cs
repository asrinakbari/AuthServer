using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

public static class Argon2PasswordHasher
{
    private const int SaltSize = 16; 
    private const int HashSize = 32; 
    private const int Iterations = 10; 
    private const int MemorySize = 65536; 
    private const int Parallelism = 4; 

    public static string HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[SaltSize];
        rng.GetBytes(salt);

        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = Parallelism,
            MemorySize = MemorySize,
            Iterations = Iterations
        };

        byte[] hash = argon2.GetBytes(HashSize);
        return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
    }

    public static PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        var parts = hashedPassword.Split('.');
        if (parts.Length != 2) return PasswordVerificationResult.Failed;

        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] storedHash = Convert.FromBase64String(parts[1]);

        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(providedPassword))
        {
            Salt = salt,
            DegreeOfParallelism = Parallelism,
            MemorySize = MemorySize,
            Iterations = Iterations
        };

        byte[] newHash = argon2.GetBytes(HashSize);

        return CryptographicOperations.FixedTimeEquals(newHash, storedHash)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
    }
}
