using System;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Battle.GameCondition
{
  public interface ICondition
  {
    void CleanUp();
    public event Action Happened;
  }
}