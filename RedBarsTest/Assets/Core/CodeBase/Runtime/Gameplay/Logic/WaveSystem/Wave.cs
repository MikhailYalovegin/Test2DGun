using System;
using System.Collections.Generic;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem
{
  [Serializable]
  public class Wave
  {
    public float Duration;
    public List<WaveEventData> Events = new();

    public Wave(float duration, List<WaveEventData> waveEvents)
    {
      Duration = duration;
      Events = waveEvents;
    }
  }
}