using UnityEngine;

namespace RBT.CodeBase.Runtime.Infrastructure.Services.Inputs
{
  public class InputService : MonoBehaviour, IInputService
  {
    public Vector2 MoveDirection =>
      _controls.Player.Move.ReadValue<Vector2>();

    public bool Fire => _controls.Player.Fire.triggered;

    public Vector2 Move => _controls.Player.Move.ReadValue<Vector2>();

    public Vector2 MousePosition => _controls.Player.MousePosition.ReadValue<Vector2>();
    private InputControls _controls;

    private void Awake()
    {
      Debug.Log("Infrastructure: Input Service Awaken");
      _controls = new InputControls();
      _controls.Enable();
    }
  }
}