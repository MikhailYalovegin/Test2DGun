using System;
using RBT.CodeBase.Runtime.Infrastructure.AssetManagement;
using RBT.CodeBase.Runtime.Infrastructure.Tools;
using RBT.CodeBase.Runtime.Infrastructure.Tools.Interfaces;
using RBT.CodeBase.Runtime.UI.Screens.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace RBT.CodeBase.Runtime.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour,
    IBootstrapper,
    IInitializable
  {
    private ICurtain _curtain;
    private ISceneLoader _sceneLoader;

    [Inject]
    private void Construct(
      ICurtain curtain,
      ICoroutineRunner coroutineRunner)
    {
      _curtain = curtain;
      _sceneLoader = new SceneLoader(coroutineRunner);
    }

    public void Load(string scene)
    {
      _curtain.Show();
      _sceneLoader.Load(scene, OnLoadedScene);
    }

    public void ReloadCurrentScene()
    {
      ReloadScene?.Invoke();
      Load(SceneManager.GetActiveScene().name);
    }

    void IInitializable.Initialize()
    {
      DontDestroyOnLoad(this);

      if (SceneManager.GetActiveScene().name == AssetName.BootstrapScene)
        Load(AssetName.MainMenuScene);
    }

    private void OnLoadedScene() =>
      _curtain.Hide();

    public event Action ReloadScene;
  }
}