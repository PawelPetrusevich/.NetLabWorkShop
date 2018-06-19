using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Interfaces;

namespace PasswordManager
{
  public class MobilePhone
  {
    public IMobileCard MobileCard { get; set; }

    public MobilePhone(IMobileCard mobileCard)
    {
      MobileCard = mobileCard;
    }

    public void Call()
    {
      MobileCard.ConnectToNetwork();
      MobileCard.SendData();
    }

    public int GetNumber()
    {
      return MobileCard.GetNumber();
    }

  }
}
