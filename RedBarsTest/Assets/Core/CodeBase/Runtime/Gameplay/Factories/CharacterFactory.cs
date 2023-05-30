using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Configs;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Enemys;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Gameplay.Factories
{
  public class CharacterFactory
  {
    private readonly DiContainer _container;

    public CharacterFactory(DiContainer container) =>
      _container = container;

    public TCharacter CreateEnemy<TCharacter>(EnemyConfig config,
      Vector3 position,
      Quaternion rotation,
      Transform parent = null) where TCharacter : CharacterBase
    {
      var character = CreateCharacter<TCharacter>(config, position, rotation, parent);

      return character;
    }

    private TCharacter CreateCharacter<TCharacter>(EnemyConfig config,
      Vector3 position,
      Quaternion rotation,
      Transform parent = null) where TCharacter : CharacterBase
    {
      var character = _container.InstantiatePrefabForComponent<TCharacter>(
        config.Character,
        position,
        rotation,
        parent);

      return character;
    }
  }
}