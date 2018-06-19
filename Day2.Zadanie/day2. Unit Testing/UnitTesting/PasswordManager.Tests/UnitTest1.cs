using System;
using System.Collections.Generic;
using System.Xml;
using HW;
using NUnit.Framework;


namespace PasswordManager.Tests
{
  [TestFixture]
  public class UnitTest1
  {
    //[Test]
    [TestCaseSource(nameof(TestCases))]
    public void TestMethod1(int age)
    {
      var calc = new PriceCalculator(100);
      calc.CalculatePrice(age);

    }


    public static List<int> TestCases()
    {
      var list = new List<int>();
      XmlDocument xDoc = new XmlDocument();

      xDoc.Load(@"D:\.NET mentoring\day2. Unit Testing\UnitTesting\PasswordManager.Tests\People.xml");
      XmlElement xRoot = xDoc.DocumentElement;

      if(xRoot != null)
      {
        foreach (XmlNode xnode in xRoot)
        {
          foreach (XmlNode childnode in xnode.ChildNodes)
          {
            if (childnode.Name == "age")
            {
              list.Add(int.Parse(childnode.InnerText));
            }
          }
        }
      }

      return list;
    }
  }
}
