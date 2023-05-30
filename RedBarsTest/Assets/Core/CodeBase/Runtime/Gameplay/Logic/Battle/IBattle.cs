using RBT.CodeBase.Runtime.UI;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Battle
{
  public interface IBattle
  {
    void PauseBattle();
    void ContinueBattle();
    void StartBattle(HUDMediator hudMediator);
  }
}