using RBT.CodeBase.Runtime.Infrastructure;
using RBT.CodeBase.Runtime.Infrastructure.AssetManagement;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Gameplay.Screens
{
  public class MainMenuScreen : MonoBehaviour
  {
    private IBootstrapper _bootstrapper;

    [Inject]
    private void Construct(IBootstrapper bootstrapper) =>
      _bootstrapper = bootstrapper;

    public void StartGame() =>
      _bootstrapper.Load(AssetName.BattleScene);

    public void EndGame()
    {
#if UNITY_EDITOR
      EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
  }
}