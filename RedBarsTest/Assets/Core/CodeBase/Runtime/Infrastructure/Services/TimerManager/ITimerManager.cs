using System;

namespace RBT.CodeBase.Runtime.Infrastructure.Services.TimerManager
{
  public interface ITimerManager
  {
    public TimeHandler AddTimer(float time, Action action);
    void Remove(TimeHandler timeHandler);
  }
}