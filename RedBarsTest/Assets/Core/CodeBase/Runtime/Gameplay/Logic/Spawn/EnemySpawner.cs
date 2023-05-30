using RBT.CodeBase.Runtime.Gameplay.Factories;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Spawn
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private BattleConfig _battleConfig;

    private CharacterFactory _factory;
    private ICharacterRegistry _registry;
    private Coroutine _waitForWaveRoutine;
    private WaveCollection _waveCollection;

    public int WaveCount => _battleConfig.WaveCount;
    public int CurrentWave => _waveCollection.CurrentWave;

    [Inject]
    private void Construct(CharacterFactory factory, ICharacterRegistry registry)
    {
      _registry = registry;
      _factory = factory;
    }

    private void Awake() =>
      _waveCollection = _battleConfig.GetWaves(_factory, _registry);

    public void NextWave()
    {
      _waveCollection.EnterCurrentWaveEvents();
      _waveCollection.NextWave();
    }

    public float GetWaveDurations() =>
      _waveCollection.GetNextDurations();
  }
}