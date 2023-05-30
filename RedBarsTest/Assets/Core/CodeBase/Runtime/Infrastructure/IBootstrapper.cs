using System;

namespace RBT.CodeBase.Runtime.Infrastructure
{
  public interface IBootstrapper
  {
    void ReloadCurrentScene();
    void Load(string scene);
    event Action ReloadScene;
  }
}