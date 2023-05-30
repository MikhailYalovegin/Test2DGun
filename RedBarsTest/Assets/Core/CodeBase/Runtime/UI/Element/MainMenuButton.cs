using RBT.CodeBase.Runtime.Infrastructure;
using RBT.CodeBase.Runtime.Infrastructure.AssetManagement;
using RBT.CodeBase.Runtime.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.UI.Element
{
  public class MainMenuButton : MonoBehaviour
  {
    private IBootstrapper _bootstrapper;
    private PauseService _pauseService;

    [Inject]
    private void Construct(IBootstrapper bootstrapper, PauseService pauseService)
    {
      _pauseService = pauseService;
      _bootstrapper = bootstrapper;
    }

    public void OnClick()
    {
      _pauseService.ContinueGame();
      _bootstrapper.Load(AssetName.MainMenuScene);
    }
  }
}