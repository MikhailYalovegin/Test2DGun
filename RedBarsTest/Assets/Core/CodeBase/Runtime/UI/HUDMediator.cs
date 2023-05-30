using UnityEngine;

namespace RBT.CodeBase.Runtime.UI
{
  public class HUDMediator : MonoBehaviour
  {
    [SerializeField] private WinLoseTitle _winLoseTitle;
    [SerializeField] private HUDMainPanel _mainPanel;
    [SerializeField] private PauseWindow _pauseWindow;

    public void Initialize()
    {
      _winLoseTitle.Initialize(this);
      _mainPanel.Initialize(this);
      _pauseWindow.Initialize();
    }

    public void ShowWin()
    {
      HidePauseButton();
      _winLoseTitle.ShowWinTitle();
    }

    public void ShowLose()
    {
      HidePauseButton();
      _winLoseTitle.ShowLoseTitle();
    }

    public void SetTimeOut(float time) => _winLoseTitle.SetTimeOut(time);

    public void SetCurrentWave(int level) => _winLoseTitle.SetCurrentLevel(level);
    public void HidePauseButton() => _mainPanel.PauseButton.SwitcherVisible(false);
    public void ShowPauseButton() => _mainPanel.PauseButton.SwitcherVisible(true);
    public void SwitchPauseWindow() => _pauseWindow.SwitchCanvasPause();
    public void HideContinueButton() => _winLoseTitle.ContinueButton.SwitcherVisible(false);
  }
}