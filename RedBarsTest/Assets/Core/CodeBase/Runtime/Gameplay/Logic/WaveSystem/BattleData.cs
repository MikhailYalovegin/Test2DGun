using System;
using System.Collections.Generic;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.WaveSystem
{
  [Serializable]
  public class BattleData
  {
    [SerializeField] public List<WaveEventData> Events = new();
    [SerializeField] public float Duration;
  }
}