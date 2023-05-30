using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Factories;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem.Events;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem
{
  public class WaveCollection
  {
    private readonly List<Wave> _waves;

    private readonly CharacterFactory _characterFactory;
    private readonly ICharacterRegistry _registry;

    public int CurrentWave { get; private set; }
    private List<SpawnEnemyEvent> _events = new();

    public WaveCollection(List<Wave> waves, CharacterFactory characterFactory, ICharacterRegistry registry)
    {
      _registry = registry;
      _characterFactory = characterFactory;
      _waves = waves;
    }

    public void EnterCurrentWaveEvents()
    {
      _events = new List<SpawnEnemyEvent>();
      foreach (WaveEventData waveEvent in _waves[CurrentWave].Events)
      {
        SpawnEnemyEvent @event = waveEvent.EventConfig.GetEvent(_characterFactory, waveEvent.Amount, _registry);
        @event.Enter();
        _events.Add(@event);
      }
    }

    public void NextWave()
    {
      if (CurrentWave < _waves.Count)
        ++CurrentWave;
    }

    public float GetNextDurations() =>
      _waves[CurrentWave].Duration;
  }
}