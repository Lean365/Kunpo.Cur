// -----------------------------------------------------------------------
// <copyright file="KpPasswordHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>密码帮助类</summary>
// -----------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 密码帮助类
  /// </summary>
  public static class KpPasswordHelper
  {
    /// <summary>
    /// 默认迭代次数
    /// </summary>
    private const int DefaultIterations = 10000;

    /// <summary>
    /// 默认密钥长度
    /// </summary>
    private const int DefaultKeyLength = 32;

    /// <summary>
    /// 默认盐值长度
    /// </summary>
    private const int DefaultSaltLength = 16;

    /// <summary>
    /// 生成随机盐值
    /// </summary>
    /// <param name="length">盐值长度</param>
    /// <returns>Base64编码的盐值</returns>
    public static string GenerateSalt(int length = DefaultSaltLength)
    {
      byte[] salt = new byte[length];
      RandomNumberGenerator.Fill(salt);
      return Convert.ToBase64String(salt);
    }

    /// <summary>
    /// 使用PBKDF2算法加密密码
    /// </summary>
    /// <param name="password">原始密码</param>
    /// <param name="salt">盐值</param>
    /// <param name="iterations">迭代次数</param>
    /// <param name="keyLength">密钥长度</param>
    /// <returns>加密后的密码</returns>
    public static string HashPassword(string password, string salt, int iterations = DefaultIterations, int keyLength = DefaultKeyLength)
    {
      if (string.IsNullOrEmpty(password))
        throw new ArgumentNullException(nameof(password), "密码不能为空");

      if (string.IsNullOrEmpty(salt))
        throw new ArgumentNullException(nameof(salt), "盐值不能为空");

      byte[] saltBytes = Convert.FromBase64String(salt);
      byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

      using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations, HashAlgorithmName.SHA256))
      {
        byte[] hash = pbkdf2.GetBytes(keyLength);
        return Convert.ToBase64String(hash);
      }
    }

    /// <summary>
    /// 验证密码
    /// </summary>
    /// <param name="password">原始密码</param>
    /// <param name="salt">盐值</param>
    /// <param name="hashedPassword">加密后的密码</param>
    /// <param name="iterations">迭代次数</param>
    /// <param name="keyLength">密钥长度</param>
    /// <returns>密码是否匹配</returns>
    public static bool VerifyPassword(string password, string salt, string hashedPassword, int iterations = DefaultIterations, int keyLength = DefaultKeyLength)
    {
      if (string.IsNullOrEmpty(password))
        throw new ArgumentNullException(nameof(password), "密码不能为空");

      if (string.IsNullOrEmpty(salt))
        throw new ArgumentNullException(nameof(salt), "盐值不能为空");

      if (string.IsNullOrEmpty(hashedPassword))
        throw new ArgumentNullException(nameof(hashedPassword), "加密后的密码不能为空");

      string computedHash = HashPassword(password, salt, iterations, keyLength);
      return computedHash == hashedPassword;
    }

    /// <summary>
    /// 生成密码哈希和盐值
    /// </summary>
    /// <param name="password">原始密码</param>
    /// <param name="iterations">迭代次数</param>
    /// <param name="keyLength">密钥长度</param>
    /// <param name="saltLength">盐值长度</param>
    /// <returns>包含哈希和盐值的元组</returns>
    public static (string Hash, string Salt) GenerateHashAndSalt(string password, int iterations = DefaultIterations, int keyLength = DefaultKeyLength, int saltLength = DefaultSaltLength)
    {
      string salt = GenerateSalt(saltLength);
      string hash = HashPassword(password, salt, iterations, keyLength);
      return (hash, salt);
    }

    /// <summary>
    /// 使用Argon2id算法加密密码（如果可用）
    /// </summary>
    /// <param name="password">原始密码</param>
    /// <param name="salt">盐值</param>
    /// <returns>加密后的密码</returns>
    public static string HashPasswordWithArgon2(string password, string salt)
    {
      // 注意：这里需要添加Argon2的NuGet包，如Konscious.Security.Cryptography.Argon2
      // 由于可能没有安装该包，这里仅提供示例代码
      throw new NotImplementedException("需要安装Konscious.Security.Cryptography.Argon2包");

      // 示例代码：
      // byte[] saltBytes = Convert.FromBase64String(salt);
      // byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
      // 
      // using (var argon2 = new Argon2id(passwordBytes))
      // {
      //   argon2.Salt = saltBytes;
      //   argon2.DegreeOfParallelism = 4;
      //   argon2.Iterations = 3;
      //   argon2.MemorySize = 65536;
      //   
      //   byte[] hash = argon2.GetBytes(32);
      //   return Convert.ToBase64String(hash);
      // }
    }

    /// <summary>
    /// 使用AES加密数据
    /// </summary>
    /// <param name="plainText">明文</param>
    /// <param name="key">密钥</param>
    /// <returns>加密后的Base64字符串</returns>
    public static string Encrypt(string plainText, string key)
    {
      if (string.IsNullOrEmpty(plainText))
        throw new ArgumentNullException(nameof(plainText), "明文不能为空");

      if (string.IsNullOrEmpty(key))
        throw new ArgumentNullException(nameof(key), "密钥不能为空");

      // 使用PBKDF2从密钥生成加密密钥
      byte[] keyBytes = Encoding.UTF8.GetBytes(key);
      byte[] salt = new byte[16];
      RandomNumberGenerator.Fill(salt);

      using (var pbkdf2 = new Rfc2898DeriveBytes(keyBytes, salt, 10000, HashAlgorithmName.SHA256))
      {
        byte[] derivedKey = pbkdf2.GetBytes(32); // 256位密钥

        using (var aes = Aes.Create())
        {
          aes.Key = derivedKey;
          aes.GenerateIV(); // 生成随机IV

          using (var encryptor = aes.CreateEncryptor())
          using (var msEncrypt = new MemoryStream())
          {
            // 写入盐值和IV
            msEncrypt.Write(salt, 0, salt.Length);
            msEncrypt.Write(aes.IV, 0, aes.IV.Length);

            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
              swEncrypt.Write(plainText);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
          }
        }
      }
    }

    /// <summary>
    /// 使用AES解密数据
    /// </summary>
    /// <param name="cipherText">密文</param>
    /// <param name="key">密钥</param>
    /// <returns>解密后的明文</returns>
    public static string Decrypt(string cipherText, string key)
    {
      if (string.IsNullOrEmpty(cipherText))
        throw new ArgumentNullException(nameof(cipherText), "密文不能为空");

      if (string.IsNullOrEmpty(key))
        throw new ArgumentNullException(nameof(key), "密钥不能为空");

      byte[] fullCipher = Convert.FromBase64String(cipherText);
      byte[] salt = new byte[16];
      byte[] iv = new byte[16];

      // 提取盐值和IV
      Array.Copy(fullCipher, 0, salt, 0, salt.Length);
      Array.Copy(fullCipher, salt.Length, iv, 0, iv.Length);

      // 使用PBKDF2从密钥生成解密密钥
      byte[] keyBytes = Encoding.UTF8.GetBytes(key);
      using (var pbkdf2 = new Rfc2898DeriveBytes(keyBytes, salt, 10000, HashAlgorithmName.SHA256))
      {
        byte[] derivedKey = pbkdf2.GetBytes(32); // 256位密钥

        using (var aes = Aes.Create())
        {
          aes.Key = derivedKey;
          aes.IV = iv;

          using (var decryptor = aes.CreateDecryptor())
          using (var msDecrypt = new MemoryStream(fullCipher, salt.Length + iv.Length, fullCipher.Length - salt.Length - iv.Length))
          using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
          using (var srDecrypt = new StreamReader(csDecrypt))
          {
            return srDecrypt.ReadToEnd();
          }
        }
      }
    }
  }
}