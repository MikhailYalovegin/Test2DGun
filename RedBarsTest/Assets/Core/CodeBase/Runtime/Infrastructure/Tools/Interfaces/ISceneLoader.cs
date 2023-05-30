using System;

namespace RBT.CodeBase.Runtime.Infrastructure.Tools.Interfaces
{
  public interface ISceneLoader
  {
    void Load(string name, Action onLoaded = null);
  }
}