using RBT.CodeBase.Runtime.Gameplay.Logic.Battle;
using RBT.CodeBase.Runtime.UI.Element;
using TMPro;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.UI
{
  public class WinLoseTitle : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _lastTime;
    [SerializeField] private TextMeshProUGUI _currentLevel;
    [SerializeField] private ContinueButton _continueButton;
    
    private IBattle _battle;
    private int _level;
    private HUDMediator _mediator;
    private float _timeOut;

    public ContinueButton ContinueButton => _continueButton;

    [Inject]
    private void Construct(IBattle battle) =>
      _battle = battle;

    private void Update()
    {
      if (_timeOut < 0)
      {
        _lastTime.text = $"{0}:{00}";
        return;
      }

      _timeOut -= Time.deltaTime;
      _lastTime.text = $"{(int)(_timeOut / 60)}:{((int)(_timeOut % 60)).ToString("D2")}";
    }

    public void Initialize(HUDMediator mediator)
    {
      _mediator = mediator;
      GetComponent<Canvas>().enabled = true;
      _title.gameObject.SetActive(false);
      _continueButton.Button.onClick.AddListener(ContinueBattle);
    }

    public void ShowWinTitle()
    {
      _continueButton.SwitcherVisible(true);
      ShowTitle("Win", Color.green);
    }

    public void ShowLoseTitle()
    {
      _continueButton.SwitcherVisible(false);
      ShowTitle("Lose", Color.red);
    }

    public void SetTimeOut(float timeOut) =>
      _timeOut = timeOut;

    public void SetCurrentLevel(int level) =>
      _currentLevel.text = $"Level {level + 1}";

    public void ContinueBattle()
    {
      _continueButton.SwitcherVisible(false);
      _title.gameObject.SetActive(false);
      _mediator.ShowPauseButton();
      _battle.ContinueBattle();
    }

    private void ShowTitle(string text, Color color)
    {
      _title.gameObject.SetActive(true);
      _title.text = text;
      _title.color = color;
    }
  }
}