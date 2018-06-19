using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{

  // 1. Протестировать класс с создание примитивной заглушки для manager. Какие минусы у такого подхода? Как их можно решить?
  // 2. Протестировать класс при помощи мока
  public class LogAnalyzer
  {
    private IExtensionManager manager;

    public LogAnalyzer(IExtensionManager mgr)
    {
      manager = mgr;
    }

    public bool IsValidLogFileName(string fileleName)
    {
      return manager.IsValid(fileleName);
    }
  }

  public interface IExtensionManager
  {
    bool IsValid(string fileleName);
  }
}
