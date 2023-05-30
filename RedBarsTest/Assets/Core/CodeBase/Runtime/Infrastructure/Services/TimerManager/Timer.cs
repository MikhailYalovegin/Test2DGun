using System;

namespace RBT.CodeBase.Runtime.Infrastructure.Services.TimerManager
{
  public class Timer
  {
    public readonly Action Action;
    public float Time;

    public Timer(float time, Action action)
    {
      Action = action;
      Time = time;
    }
  }
}