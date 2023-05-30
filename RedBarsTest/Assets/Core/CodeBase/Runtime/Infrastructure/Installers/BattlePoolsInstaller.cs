using RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Players;
using RBT.CodeBase.Runtime.Pools;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Infrastructure.Installers
{
  public class BattlePoolsInstaller : MonoInstaller, IInitializable
  {
    [SerializeField] private GameObject _cannonBall;

    public void Initialize()
    {
      Debug.Log("BattlePoolsInstaller: Initialize");
      Container.Resolve<Pool<CannonBall>>().Initialize();
    }

    public override void InstallBindings()
    {
      Debug.Log("BattlePoolsInstaller: InstallBindings");
      Container.BindInterfacesTo<BattlePoolsInstaller>().FromInstance(this).AsSingle();

      Container.Bind<Pool<CannonBall>>()
        .FromMethod(context => new Pool<CannonBall>(context.Container, _cannonBall, 10)).AsSingle();
    }
  }
}