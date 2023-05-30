using RBT.CodeBase.Runtime.Infrastructure.Services.Inputs;
using RBT.CodeBase.Runtime.Infrastructure.Tools;
using RBT.CodeBase.Runtime.Infrastructure.Tools.Interfaces;
using RBT.CodeBase.Runtime.UI.Screens.Interfaces;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Infrastructure.Installers
{
  public class ApplicationInstaller : MonoInstaller
  {
    [SerializeField] private GameObject _applicationServices;
    [SerializeField] private InputService _inputService;

    public override void InstallBindings()
    {
      Debug.Log("ApplicationInstaller: InstallBindings");

      Application.targetFrameRate = 60;

      BindApplicationServices();
      BindServices();
    }

    private void BindApplicationServices()
    {
      var gameBootstrapper = FindObjectOfType<GameBootstrapper>();

      if (gameBootstrapper == null)
        gameBootstrapper = Instantiate(_applicationServices).GetComponent<GameBootstrapper>();

      Container
        .Bind(typeof(IInitializable), typeof(IBootstrapper))
        .To<GameBootstrapper>()
        .FromInstance(gameBootstrapper)
        .AsSingle();

      Container
        .Bind<ICoroutineRunner>()
        .To<CoroutineRunner>()
        .FromMethod(gameBootstrapper.GetComponentInChildren<CoroutineRunner>)
        .AsSingle();

      Container
        .Bind<ICurtain>()
        .FromMethod(gameBootstrapper.GetComponentInChildren<ICurtain>)
        .AsSingle();
    }


    private void BindServices() =>
      Container
        .Bind<IInputService>()
        .To<InputService>()
        .FromInstance(_inputService)
        .AsSingle();
  }
}