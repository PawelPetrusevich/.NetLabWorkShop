using System;
using System.Diagnostics;
using NUnit.Framework;


namespace PasswordManager.Tests
{
  [TestFixture]
  public class PasswordManagerTests
  {
    [Test]
    public void CreateRandomPassword_ShouldCreatePasswordWithRandomLength()
    {
      // arrange  (подготовка)
      var pm = new PasswordManager();
      var rnd = new Random();

      //act  (воздействие)
      var passwordLength = rnd.Next(1, 10);
      var password = pm.GenerateNewPassword(passwordLength);

      //assert  (утверждение)
      Assert.AreEqual(password.Length, passwordLength);
    }

    [Test]
    public void CreateRandomPassword_PasswordLengthShouldBeSetTo10()
    {
      // arrange
      var pm = new PasswordManager();
      var passwordLength = 10;

      //act
      var password = pm.GenerateNewPassword(passwordLength);

      //assert
      Assert.AreEqual(password.Length, passwordLength);
    }

    [TestCase(5)]
    public void CreateRandomPassword_PasswordLengthShouldBeSetFromParameter(int length)
    {
      // arrange
      var pm = new PasswordManager();

      //act
      var password = pm.GenerateNewPassword(length);

      //assert
      Assert.AreEqual(password.Length, length);
    }

  }
}
