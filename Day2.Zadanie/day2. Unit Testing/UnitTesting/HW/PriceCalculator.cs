using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
  // data-driven-tests . http://nunit.org/docs/2.6/testCaseSource.html Написать тесты с [TestCaseSource] аттрибутом
  public class PriceCalculator
  {
    private decimal price;

    public PriceCalculator(decimal adultPrice)
    {
      this.price = adultPrice;
    }

    public decimal CalculatePrice(int age)
    {
      decimal multiplier = 0.0m;

      if (age >= 5 && age < 18)
        multiplier = 0.8m;
      else if (age >= 18 && age < 60)
        multiplier = 1.0m;
      else if (age >= 60)
        multiplier = 0.5m;

      return this.price * multiplier;
    }
  }
}
