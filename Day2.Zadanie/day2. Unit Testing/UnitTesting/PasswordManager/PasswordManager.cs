using System;
using System.Text;

namespace PasswordManager
{
  public class PasswordManager
  {
    private readonly char[] AllChars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

    public string GenerateNewPassword(int passwordLength)
    {
      var password = GenerateRandomString(passwordLength);

      return password;
    }


    private string GenerateRandomString(int passwordLength)
    {
      var sb = new StringBuilder();
      var rnd = new Random();

      for (int i = 0; i < passwordLength; i++)
      {
        var randomCharIndex = rnd.Next(0, AllChars.Length);
        sb.Append(AllChars[randomCharIndex]);
      }

      return sb.ToString();
    }

    private string GenerateNumbersString(int min, int max)
    {
      var rnd = new Random();
      var randomInt = rnd.Next(0, 9999);

      return randomInt.ToString();
    }
  }
}
