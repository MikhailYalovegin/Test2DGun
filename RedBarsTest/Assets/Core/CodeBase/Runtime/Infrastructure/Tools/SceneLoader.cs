using System;
using System.Collections;
using RBT.CodeBase.Runtime.Infrastructure.Tools.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RBT.CodeBase.Runtime.Infrastructure.Tools
{
  public class SceneLoader : ISceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
      _coroutineRunner = coroutineRunner;


    public void Load(string name, Action onLoaded = null) =>
      _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

    private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
    {
      AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

      while (waitNextScene.isDone == false)
        yield return null;


      onLoaded?.Invoke();
    }
  }
}