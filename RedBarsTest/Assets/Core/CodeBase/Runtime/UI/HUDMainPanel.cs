using RBT.CodeBase.Runtime.Infrastructure.Services;
using RBT.CodeBase.Runtime.UI.Element;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.UI
{
  public class HUDMainPanel : MonoBehaviour
  {
    [SerializeField] private Canvas _canvas;
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private RestartButton _restartButton;

    public bool IsVisible
    {
      get => _canvas.enabled;
      set => _canvas.enabled = value;
    }

    public PauseButton PauseButton => _pauseButton;
    public RestartButton RestartButton => _restartButton;
    private HUDMediator _mediator;

    private PauseService _pauseService;


    [Inject]
    private void Construct(PauseService pauseService) =>
      _pauseService = pauseService;

    private void OnDestroy()
    {
      PauseButton.Button.onClick.RemoveAllListeners();

      _pauseService.SwitchPause -= _pauseButton.ChangeIcon;
    }

    public void Initialize(HUDMediator mediator)
    {
      _mediator = mediator;

      PauseButton.Button.onClick.AddListener(_pauseService.SwitchPauseGame);
      PauseButton.Button.onClick.AddListener(_mediator.SwitchPauseWindow);

      _pauseService.SwitchPause += _pauseButton.ChangeIcon;

      IsVisible = true;
    }
  }
}