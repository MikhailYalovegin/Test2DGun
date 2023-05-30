using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Factories;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Configs;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Enemys;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem.Events
{
  public class SpawnEnemyEvent : ScriptableObject
  {
    private readonly EnemyConfig _enemyConfig;
    private readonly int _amount;
    private readonly CharacterFactory _characterFactory;
    private readonly ICharacterRegistry _registry;
    private Transform _enemyParent;

    public SpawnEnemyEvent(EnemyConfig enemyConfig, int amount, CharacterFactory characterFactory, ICharacterRegistry registry)
    {
      _registry = registry;
      _amount = amount;
      _characterFactory = characterFactory;
      _enemyConfig = enemyConfig;
    }

    public void Enter()
    {
      _enemyParent = GameObject.Find(SceneParentNames.SpawnedEnemies).transform;
      SpawnEnemiesRandomAroundPlayer(_amount);
    }

    private void SpawnEnemiesRandomAroundPlayer(int amount)
    {
      var newbies = new List<CharacterBase>();
      for (var i = 0; i < amount; ++i)
      {
        var enemy = _characterFactory.CreateEnemy<CharacterBase>(_enemyConfig, Vector3.one, Quaternion.identity, _enemyParent);
        newbies.Add(enemy);
      }

      _registry.RegisterEnemies(newbies);
    }
  }
}