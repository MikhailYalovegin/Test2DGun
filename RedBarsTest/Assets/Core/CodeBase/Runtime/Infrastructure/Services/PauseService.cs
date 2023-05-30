using System;
using UnityEngine;

namespace RBT.CodeBase.Runtime.Infrastructure.Services
{
  public class PauseService
  {
    public bool Pause { get; private set; }

    public Action<bool> SwitchPause;

    public void PauseGame()
    {
      Pause = true;
      Time.timeScale = 0;
      SwitchPause?.Invoke(Pause);
    }

    public void ContinueGame()
    {
      Pause = false;
      Time.timeScale = 1;
      SwitchPause?.Invoke(Pause);
    }

    public void SetGameState(bool isVisible)
    {
      if (isVisible)
        PauseGame();
      else
        ContinueGame();
    }

    public void SwitchPauseGame()
    {
      Pause = !Pause;
      SetGameState(Pause);
    }
  }
}