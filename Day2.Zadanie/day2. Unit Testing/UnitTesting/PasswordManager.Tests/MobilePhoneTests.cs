using System;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PasswordManager.Interfaces;

namespace PasswordManager.Tests
{
  [TestFixture]
  public class MobilePhoneTests
  {
    private Mock<IMobileCard> fakeMobileCartCard;

    [SetUp]
    public void SetUp()
    {
      fakeMobileCartCard = new Mock<IMobileCard>();
      fakeMobileCartCard.Setup(card => card.ConnectToNetwork());
      fakeMobileCartCard.Setup(card => card.SendData());
      fakeMobileCartCard.Setup(p => p.GetNumber()).Returns(3224168);
    }

    [TearDown]
    public void Test()
    {
      fakeMobileCartCard = null;
    }

    [Test]
    public void Call_InvokedConnectToNetwork_OneTime()
    {
      var pnone = new MobilePhone(fakeMobileCartCard.Object);

      pnone.Call();

      fakeMobileCartCard.Verify(p => p.ConnectToNetwork(), Times.AtMostOnce);
    }

    [Test]
    public void GetNumber_ReturnedNumberFromCard()
    {
      var pnone = new MobilePhone(fakeMobileCartCard.Object);

      var number = pnone.GetNumber();

      Assert.AreEqual(number,3224168);
    }

  }
}
