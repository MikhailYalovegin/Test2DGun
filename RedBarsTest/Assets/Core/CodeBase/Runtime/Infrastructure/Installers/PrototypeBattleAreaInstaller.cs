using RBT.CodeBase.Runtime.Gameplay.Factories;
using RBT.CodeBase.Runtime.Gameplay.Logic.Battle;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.Spawn;
using RBT.CodeBase.Runtime.Infrastructure.Services;
using RBT.CodeBase.Runtime.Infrastructure.Services.TimerManager;
using RBT.CodeBase.Runtime.UI;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Infrastructure.Installers
{
  public class PrototypeBattleAreaInstaller : MonoInstaller, IInitializable
  {
    [SerializeField] private HUDMediator _mediator;
    [SerializeField] private EnemySpawner _enemySpawner;

    public void Initialize()
    {
      Debug.Log("PrototypeBattleAreaInstaller: Initialize");

      var mediator = Container.Resolve<HUDMediator>();
      mediator.Initialize();
      var battle = Container.Resolve<IBattle>();
      battle.StartBattle(mediator);
    }

    public override void InstallBindings()
    {
      Debug.Log("PrototypeBattleAreaInstaller: InstallBindings");

      Container
        .BindInterfacesTo<PrototypeBattleAreaInstaller>()
        .FromInstance(this)
        .AsSingle();

      Container
        .Bind<EnemySpawner>()
        .FromInstance(_enemySpawner)
        .AsSingle();

      Container
        .Bind<CharacterFactory>()
        .AsSingle();

      Container
        .Bind<ICharacterRegistry>()
        .To<CharacterRegistry>()
        .AsSingle();

      Container
        .Bind(typeof(ITimerManager),
          typeof(ITimeUpdater))
        .To<TimerManager>()
        .AsSingle();

      Container
        .Bind<HUDMediator>()
        .FromInstance(_mediator)
        .AsSingle();

      Container
        .BindInterfacesTo<Battle>()
        .AsSingle();

      Container
        .Bind<PauseService>()
        .FromNew()
        .AsSingle();
    }
  }
}