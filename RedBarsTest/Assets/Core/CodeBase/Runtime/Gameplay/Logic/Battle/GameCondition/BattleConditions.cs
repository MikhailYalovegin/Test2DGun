using System;
using System.Collections.Generic;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Battle.GameCondition
{
  public class BattleConditions
  {
    private readonly List<ICondition> _loseConditions;
    private readonly List<ICondition> _winConditions;

    public BattleConditions(List<ICondition> winConditions, List<ICondition> loseConditions)
    {
      _winConditions = winConditions;
      _loseConditions = loseConditions;

      foreach (ICondition winCondition in _winConditions)
        winCondition.Happened += OnLose;

      foreach (ICondition loseCondition in _loseConditions)
        loseCondition.Happened += OnWin;
    }

    public void CleanUp()
    {
      foreach (ICondition winCondition in _winConditions)
      {
        winCondition.CleanUp();
        winCondition.Happened -= OnLose;
      }

      foreach (ICondition loseCondition in _loseConditions)
      {
        loseCondition.CleanUp();
        loseCondition.Happened -= OnWin;
      }
    }

    private void OnLose() =>
      ConditionCompleted?.Invoke(false);

    private void OnWin() =>
      ConditionCompleted?.Invoke(true);

    public event Action<bool> ConditionCompleted;
  }
}