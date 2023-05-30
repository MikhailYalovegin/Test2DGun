using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Factories;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem
{
  [CreateAssetMenu(fileName = "New_WaveCollection", menuName = "Wave/New Wave Collection", order = 0)]
  public class BattleConfig : ScriptableObject
  {
    [SerializeField] private List<BattleData> _wavesData = new();

    public int WaveCount => _wavesData.Count;
    
    public WaveCollection GetWaves(CharacterFactory characterFactory, ICharacterRegistry registry)
    {
      List<Wave> waves = new();

      foreach (BattleData waveData in _wavesData)
      {
        List<WaveEventData> waveEvents = new();

        foreach (WaveEventData waveEventData in waveData.Events)
          waveEvents.Add(waveEventData);

        waves.Add(new Wave(waveData.Duration, waveEvents));
      }

      return new WaveCollection(waves, characterFactory, registry);
    }
  }
}