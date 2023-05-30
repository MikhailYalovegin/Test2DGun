using RBT.CodeBase.Runtime.Infrastructure;
using RBT.CodeBase.Runtime.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.UI.Element
{
  public class RestartButton : MonoBehaviour
  {
    private IBootstrapper _bootstrapper;
    private PauseService _pauseService;

    [Inject]
    private void Construct(IBootstrapper gameBootstrapper, PauseService pauseService)
    {
      _pauseService = pauseService;
      _bootstrapper = gameBootstrapper;
    }

    public void OnClick()
    {
      _bootstrapper.ReloadCurrentScene();
      _pauseService.ContinueGame();
    }
  }
}