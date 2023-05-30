using System;
using RBT.CodeBase.Runtime.Infrastructure.Services.TimerManager;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Battle.GameCondition
{
  public class TimeOutCondition : ICondition
  {
    private readonly TimeHandler _handler;
    private readonly ITimerManager _timerManager;

    public TimeOutCondition(ITimerManager timerManager, float timeOut)
    {
      _timerManager = timerManager;

      _handler = _timerManager.AddTimer(timeOut, OnTimeOut);
    }

    public void CleanUp() =>
      _timerManager.Remove(_handler);

    private void OnTimeOut() =>
      Happened?.Invoke();

    public event Action Happened;
  }
}