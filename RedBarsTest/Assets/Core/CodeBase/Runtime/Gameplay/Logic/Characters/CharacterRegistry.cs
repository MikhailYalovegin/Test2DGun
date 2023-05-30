using System;
using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Enemys;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters
{
  public class CharacterRegistry : ICharacterRegistry
  {
    private readonly List<CharacterBase> _enemies = new();

    public void RegisterEnemies(IEnumerable<CharacterBase> ships) =>
      _enemies.AddRange(ships);

    public void UnregisterCharacter(CharacterBase character)
    {
      _enemies.Remove(character);
      if (_enemies.Count == 0)
        OnAllEnemiesDeadead?.Invoke();
    }

    public event Action OnAllEnemiesDeadead;
  }
}