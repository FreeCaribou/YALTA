using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Yalta.Utils
{
  public sealed class HashingOptions
  {
    public int Iterations { get; set; } = 10000;
  }

  public sealed class PasswordHasher : IPasswordHasher
  {
    private const int SaltSize = 16; // 128 bit 
    private const int KeySize = 32; // 256 bit

    public PasswordHasher(IOptions<HashingOptions> options)
    {
      Options = options.Value;
    }

    public PasswordHasher()
    {
    }

    private HashingOptions Options { get; }

    public string Hash(string password)
    {
      using (var algorithm = new Rfc2898DeriveBytes(
        password,
        SaltSize,
        10000,
        HashAlgorithmName.SHA512))
      {
        var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{10000}.{salt}.{key}";
      }
    }

    public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
    {
      var parts = hash.Split('.', 3);

      if (parts.Length != 3)
      {
        throw new FormatException("Unexpected hash format. " +
          "Should be formatted as `{iterations}.{salt}.{hash}`");
      }

      var iterations = Convert.ToInt32(parts[0]);
      var salt = Convert.FromBase64String(parts[1]);
      var key = Convert.FromBase64String(parts[2]);

      var needsUpgrade = iterations != 10000;

      using (var algorithm = new Rfc2898DeriveBytes(
        password,
        salt,
        iterations,
        HashAlgorithmName.SHA512))
      {
        var keyToCheck = algorithm.GetBytes(KeySize);

        var verified = keyToCheck.SequenceEqual(key);

        return (verified, needsUpgrade);
      }
    }
  }
}