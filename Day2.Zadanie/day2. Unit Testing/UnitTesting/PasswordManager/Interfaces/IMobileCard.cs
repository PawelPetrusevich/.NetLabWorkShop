using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Interfaces
{
  public interface IMobileCard
  {
    string OperatorName { get; set; }
    void ConnectToNetwork();
    void SendData();
    int GetNumber();
  }
}
