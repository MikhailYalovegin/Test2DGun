using UnityEngine;

namespace RBT.CodeBase.Runtime.Infrastructure.Services.Inputs
{
  public interface IInputService
  {
    Vector2 MoveDirection { get; }
    bool Fire { get; }

    Vector2 Move { get; }

    Vector2 MousePosition { get; }
  }
}