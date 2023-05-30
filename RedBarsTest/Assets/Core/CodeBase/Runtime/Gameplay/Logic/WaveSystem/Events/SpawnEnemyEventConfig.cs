using RBT.CodeBase.Runtime.Gameplay.Factories;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Configs;
using RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem.Events;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem
{
  [CreateAssetMenu(fileName = "New_SpawnEnemyEvent", menuName = "Wave/Events/New spawn enemy event")]
  public class SpawnEnemyEventConfig : ScriptableObject
  {
    [SerializeField] private EnemyConfig _enemy;

    public SpawnEnemyEvent GetEvent(CharacterFactory characterFactory, int amount, ICharacterRegistry registry) => new(_enemy, amount, characterFactory, registry);
  }
}