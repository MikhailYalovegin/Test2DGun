using System;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Battle.GameCondition
{
  public class AllEnemiesDeadCondition : ICondition
  {
    private readonly ICharacterRegistry _characterRegistry;

    public AllEnemiesDeadCondition(ICharacterRegistry characterRegistry)
    {
      _characterRegistry = characterRegistry;
      _characterRegistry.OnAllEnemiesDeadead += OnAllEnemiesDeadead;
    }

    public void CleanUp() =>
      _characterRegistry.OnAllEnemiesDeadead -= OnAllEnemiesDeadead;

    private void OnAllEnemiesDeadead() =>
      Happened?.Invoke();

    public event Action Happened;
  }
}