using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters
{
  public abstract class CharacterBase : MonoBehaviour
  {
    protected ICharacterRegistry Registry;

    [Inject]
    private void Construct(ICharacterRegistry registry) =>
      Registry = registry;


    protected virtual void OnDead() =>
      Registry.UnregisterCharacter(this);
  }
}