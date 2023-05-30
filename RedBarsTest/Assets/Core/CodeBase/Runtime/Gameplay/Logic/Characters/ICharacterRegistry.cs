using System;
using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Enemys;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters
{
  public interface ICharacterRegistry
  {
    void RegisterEnemies(IEnumerable<CharacterBase> ships);
    void UnregisterCharacter(CharacterBase character);
    public event Action OnAllEnemiesDeadead;
  }
}