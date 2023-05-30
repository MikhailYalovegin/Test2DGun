using System;
using System.Collections.Generic;

namespace RBT.CodeBase.Runtime.Infrastructure.Services.TimerManager
{
  public class TimerManager : ITimeUpdater, ITimerManager
  {
    private readonly Dictionary<TimeHandler, Timer> _timers = new();

    public TimeHandler AddTimer(float time, Action action)
    {
      var timer = new Timer(time, action);
      var timeHandler = new TimeHandler();

      _timers.Add(timeHandler, timer);

      return timeHandler;
    }

    public void Remove(TimeHandler timeHandler)
    {
      if (_timers.ContainsKey(timeHandler))
        _timers.Remove(timeHandler);
    }

    public void Update(float deltaTime)
    {
      var endTimer = new List<TimeHandler>();

      foreach (KeyValuePair<TimeHandler, Timer> keyValuePair in _timers)
      {
        keyValuePair.Value.Time -= deltaTime;
        if (keyValuePair.Value.Time <= 0)
          endTimer.Add(keyValuePair.Key);
      }

      foreach (TimeHandler timeHandler in endTimer)
      {
        Timer timer = _timers[timeHandler];
        _timers.Remove(timeHandler);
        timer.Action?.Invoke();
      }
    }
  }
}